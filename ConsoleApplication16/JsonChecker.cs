namespace ConsoleApplication16
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    sealed class JsonChecker
    {
        int _state;
        long _offset;
        readonly int _depth;
        readonly Stack<Mode> _stack;

        const int __ = -1; /* the universal error code */

        /*
            Characters are mapped into these 31 character classes. This allows for
            a significant reduction in the size of the state transition table.
        */

        const int C_SPACE = 0; /* space */
        const int C_WHITE = 1; /* other whitespace */
        const int C_LCURB = 2; /* {  */
        const int C_RCURB = 3; /* } */
        const int C_LSQRB = 4; /* [ */
        const int C_RSQRB = 5; /* ] */
        const int C_COLON = 6; /* : */
        const int C_COMMA = 7; /* ; */
        const int C_QUOTE = 8; /* " */
        const int C_BACKS = 9; /* \ */
        const int C_SLASH = 10; /* / */
        const int C_PLUS = 11; /* + */
        const int C_MINUS = 12; /* - */
        const int C_POINT = 13; /* . */
        const int C_ZERO = 14; /* 0 */
        const int C_DIGIT = 15; /* 123456789 */
        const int C_LOW_A = 16; /* a */
        const int C_LOW_B = 17; /* b */
        const int C_LOW_C = 18; /* c */
        const int C_LOW_D = 19; /* d */
        const int C_LOW_E = 20; /* e */
        const int C_LOW_F = 21; /* f */
        const int C_LOW_L = 22; /* l */
        const int C_LOW_N = 23; /* n */
        const int C_LOW_R = 24; /* r */
        const int C_LOW_S = 25; /* s */
        const int C_LOW_T = 26; /* t */
        const int C_LOW_U = 27; /* u */
        const int C_ABCDF = 28; /* ABCDF */
        const int C_E = 29; /* E */
        const int C_ETC = 30; /* everything else */
        const int NR_CLASSES = 31;

        static readonly int[] ascii_class = new int[128]
        {
            /*
                This array maps the 128 ASCII characters into character classes.
                The remaining Unicode characters should be mapped to C_ETC.
                Non-whitespace control characters are errors.
            */
            __, __, __, __, __, __, __, __,
            __, C_WHITE, C_WHITE, __, __, C_WHITE, __, __,
            __, __, __, __, __, __, __, __,
            __, __, __, __, __, __, __, __,
            C_SPACE, C_ETC, C_QUOTE, C_ETC, C_ETC, C_ETC, C_ETC, C_ETC,
            C_ETC, C_ETC, C_ETC, C_PLUS, C_COMMA, C_MINUS, C_POINT, C_SLASH,
            C_ZERO, C_DIGIT, C_DIGIT, C_DIGIT, C_DIGIT, C_DIGIT, C_DIGIT, C_DIGIT,
            C_DIGIT, C_DIGIT, C_COLON, C_ETC, C_ETC, C_ETC, C_ETC, C_ETC,
            C_ETC, C_ABCDF, C_ABCDF, C_ABCDF, C_ABCDF, C_E, C_ABCDF, C_ETC,
            C_ETC, C_ETC, C_ETC, C_ETC, C_ETC, C_ETC, C_ETC, C_ETC,
            C_ETC, C_ETC, C_ETC, C_ETC, C_ETC, C_ETC, C_ETC, C_ETC,
            C_ETC, C_ETC, C_ETC, C_LSQRB, C_BACKS, C_RSQRB, C_ETC, C_ETC,
            C_ETC, C_LOW_A, C_LOW_B, C_LOW_C, C_LOW_D, C_LOW_E, C_LOW_F, C_ETC,
            C_ETC, C_ETC, C_ETC, C_ETC, C_LOW_L, C_ETC, C_LOW_N, C_ETC,
            C_ETC, C_ETC, C_LOW_R, C_LOW_S, C_LOW_T, C_LOW_U, C_ETC, C_ETC,
            C_ETC, C_ETC, C_ETC, C_LCURB, C_ETC, C_RCURB, C_ETC, C_ETC
        };

        /*
            The state codes.
        */

        const int GO = 00; /* start    */
        const int OK = 01; /* ok       */
        const int OB = 02; /* object   */
        const int KE = 03; /* key      */
        const int CO = 04; /* colon    */
        const int VA = 05; /* value    */
        const int AR = 06; /* array    */
        const int ST = 07; /* string   */
        const int ES = 08; /* escape   */
        const int U1 = 09; /* u1       */
        const int U2 = 10; /* u2       */
        const int U3 = 11; /* u3       */
        const int U4 = 12; /* u4       */
        const int MI = 13; /* minus    */
        const int ZE = 14; /* zero     */
        const int IN = 15; /* integer  */
        const int FR = 16; /* fraction */
        const int E1 = 17; /* e        */
        const int E2 = 18; /* ex       */
        const int E3 = 19; /* exp      */
        const int T1 = 20; /* tr       */
        const int T2 = 21; /* tru      */
        const int T3 = 22; /* true     */
        const int F1 = 23; /* fa       */
        const int F2 = 24; /* fal      */
        const int F3 = 25; /* fals     */
        const int F4 = 26; /* false    */
        const int N1 = 27; /* nu       */
        const int N2 = 28; /* nul      */
        const int N3 = 29; /* null     */
        const int NR_STATES = 30;

        static readonly int[,] state_transition_table = new int[NR_STATES, NR_CLASSES]
        {
            /*
            The state transition table takes the current state and the current symbol,
            and returns either a new state or an action. An action is represented as a
            negative number. A JSON text is accepted if at the end of the text the
            state is OK and if the mode is Done.
    
                                 white                                      1-9                                   ABCDF  etc
                             space |  {  }  [  ]  :  ,  "  \  /  +  -  .  0  |  a  b  c  d  e  f  l  n  r  s  t  u  |  E  |*/
            /*start  GO*/
            {
                GO, GO, -6, __, -5, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __,
                __,
                __, __, __, __
            },
            /*ok     OK*/
            {
                OK, OK, __, -8, __, -7, __, -3, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __,
                __,
                __, __, __, __
            },
            /*object OB*/
            {
                OB, OB, __, -9, __, __, __, __, ST, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __,
                __,
                __, __, __, __
            },
            /*key    KE*/
            {
                KE, KE, __, __, __, __, __, __, ST, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __,
                __,
                __, __, __, __
            },
            /*colon  CO*/
            {
                CO, CO, __, __, __, __, -2, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __,
                __,
                __, __, __, __
            },
            /*value  VA*/
            {
                VA, VA, -6, __, -5, __, __, __, ST, __, __, __, MI, __, ZE, IN, __, __, __, __, __, F1, __, N1, __, __,
                T1,
                __, __, __, __
            },
            /*array  AR*/
            {
                AR, AR, -6, __, -5, -7, __, __, ST, __, __, __, MI, __, ZE, IN, __, __, __, __, __, F1, __, N1, __, __,
                T1,
                __, __, __, __
            },
            /*string ST*/
            {
                ST, __, ST, ST, ST, ST, ST, ST, -4, ES, ST, ST, ST, ST, ST, ST, ST, ST, ST, ST, ST, ST, ST, ST, ST, ST,
                ST,
                ST, ST, ST, ST
            },
            /*escape ES*/
            {
                __, __, __, __, __, __, __, __, ST, ST, ST, __, __, __, __, __, __, ST, __, __, __, ST, __, ST, ST, __,
                ST,
                U1, __, __, __
            },
            /*u1     U1*/
            {
                __, __, __, __, __, __, __, __, __, __, __, __, __, __, U2, U2, U2, U2, U2, U2, U2, U2, __, __, __, __,
                __,
                __, U2, U2, __
            },
            /*u2     U2*/
            {
                __, __, __, __, __, __, __, __, __, __, __, __, __, __, U3, U3, U3, U3, U3, U3, U3, U3, __, __, __, __,
                __,
                __, U3, U3, __
            },
            /*u3     U3*/
            {
                __, __, __, __, __, __, __, __, __, __, __, __, __, __, U4, U4, U4, U4, U4, U4, U4, U4, __, __, __, __,
                __,
                __, U4, U4, __
            },
            /*u4     U4*/
            {
                __, __, __, __, __, __, __, __, __, __, __, __, __, __, ST, ST, ST, ST, ST, ST, ST, ST, __, __, __, __,
                __,
                __, ST, ST, __
            },
            /*minus  MI*/
            {
                __, __, __, __, __, __, __, __, __, __, __, __, __, __, ZE, IN, __, __, __, __, __, __, __, __, __, __,
                __,
                __, __, __, __
            },
            /*zero   ZE*/
            {
                OK, OK, __, -8, __, -7, __, -3, __, __, __, __, __, FR, __, __, __, __, __, __, __, __, __, __, __, __,
                __,
                __, __, __, __
            },
            /*int    IN*/
            {
                OK, OK, __, -8, __, -7, __, -3, __, __, __, __, __, FR, IN, IN, __, __, __, __, E1, __, __, __, __, __,
                __,
                __, __, E1, __
            },
            /*frac   FR*/
            {
                OK, OK, __, -8, __, -7, __, -3, __, __, __, __, __, __, FR, FR, __, __, __, __, E1, __, __, __, __, __,
                __,
                __, __, E1, __
            },
            /*e      E1*/
            {
                __, __, __, __, __, __, __, __, __, __, __, E2, E2, __, E3, E3, __, __, __, __, __, __, __, __, __, __,
                __,
                __, __, __, __
            },
            /*ex     E2*/
            {
                __, __, __, __, __, __, __, __, __, __, __, __, __, __, E3, E3, __, __, __, __, __, __, __, __, __, __,
                __,
                __, __, __, __
            },
            /*exp    E3*/
            {
                OK, OK, __, -8, __, -7, __, -3, __, __, __, __, __, __, E3, E3, __, __, __, __, __, __, __, __, __, __,
                __,
                __, __, __, __
            },
            /*tr     T1*/
            {
                __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, T2, __,
                __,
                __, __, __, __
            },
            /*tru    T2*/
            {
                __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __,
                __,
                T3, __, __, __
            },
            /*true   T3*/
            {
                __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, OK, __, __, __, __, __,
                __,
                __, __, __, __
            },
            /*fa     F1*/
            {
                __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, F2, __, __, __, __, __, __, __, __, __,
                __,
                __, __, __, __
            },
            /*fal    F2*/
            {
                __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, F3, __, __, __,
                __,
                __, __, __, __
            },
            /*fals   F3*/
            {
                __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, F4,
                __,
                __, __, __, __
            },
            /*false  F4*/
            {
                __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, OK, __, __, __, __, __,
                __,
                __, __, __, __
            },
            /*nu     N1*/
            {
                __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __,
                __,
                N2, __, __, __
            },
            /*nul    N2*/
            {
                __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, N3, __, __, __,
                __,
                __, __, __, __
            },
            /*null   N3*/
            {
                __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, __, OK, __, __, __,
                __,
                __, __, __, __
            },
        };

        /*
            These modes can be pushed on the stack.
        */

        [Serializable]
        enum Mode
        {
            Array,
            Done,
            Key,
            Object,
        };

        public const int NoDepthLimit = 0;

        public JsonChecker()
            : this(NoDepthLimit)
        {
        }

        public JsonChecker(int depth)
        {
            if (depth < 0)
                throw new ArgumentOutOfRangeException("depth", depth, null);

            /*
                Starts the checking process by constructing a JsonChecker
                object. It takes a depth parameter that restricts the level of maximum
                nesting.

                To continue the process, call Check for each character in the
                JSON text, and then call FinalCheck to obtain the final result.
                These functions are fully reentrant.

                The JsonChecker object will be deleted by FinalCheck.
                Check will delete the JsonChecker object if it sees an error.
            */
            this._state = GO;
            this._depth = depth;
            this._stack = new Stack<Mode>(depth);
            this.Push(Mode.Done);
        }

        public void Check(int ch)
        {
            /*
                After calling new_JSON_checker, call this function for each character (or
                partial character) in your JSON text. It can accept UTF-8, UTF-16, or
                UTF-32. It returns if things are looking ok so far. If it rejects the
                text, it throws an exception.
            */
            int nextClass;
            /*
                Determine the character's class.
            */
            if (ch < 0)
                this.OnError();
            if (ch >= 128)
                nextClass = C_ETC;
            else
            {
                nextClass = ascii_class[ch];
                if (nextClass <= __)
                    this.OnError();
            }
            /*
                Get the next state from the state transition table.
            */
            int nextState = state_transition_table[this._state, nextClass];
            if (nextState >= 0)
            {
                /*
                    Change the state.
                */
                this._state = nextState;
            }
            else
            {
                /*
                    Or perform one of the actions.
                */
                switch (nextState)
                {
                    /* empty } */
                    case -9:
                        this.Pop(Mode.Key);
                        this._state = OK;
                        break;

                    /* } */
                    case -8:
                        this.Pop(Mode.Object);
                        this._state = OK;
                        break;

                    /* ] */
                    case -7:
                        this.Pop(Mode.Array);
                        this._state = OK;
                        break;

                    /* { */
                    case -6:
                        this.Push(Mode.Key);
                        this._state = OB;
                        break;

                    /* [ */
                    case -5:
                        this.Push(Mode.Array);
                        this._state = AR;
                        break;

                    /* " */
                    case -4:
                        switch (this._stack.Peek())
                        {
                            case Mode.Key:
                                this._state = CO;
                                break;
                            case Mode.Array:
                            case Mode.Object:
                                this._state = OK;
                                break;
                            default:
                                this.OnError();
                                break;
                        }
                        break;

                    /* , */
                    case -3:
                        switch (this._stack.Peek())
                        {
                            case Mode.Object:
                                /*
                                    A comma causes a flip from object mode to key mode.
                                */
                                this.Pop(Mode.Object);
                                this.Push(Mode.Key);
                                this._state = KE;
                                break;
                            case Mode.Array:
                                this._state = VA;
                                break;
                            default:
                                this.OnError();
                                break;
                        }
                        break;

                    /* : */
                    case -2:
                        /*
                            A colon causes a flip from key mode to object mode.
                        */
                        this.Pop(Mode.Key);
                        this.Push(Mode.Object);
                        this._state = VA;
                        break;
                    /*
                    Bad action.
                */
                    default:
                        this.OnError();
                        break;
                }
            }

            this._offset++;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FinalCheck()
        {
            /*
                The FinalCheck function should be called after all of the characters
                have been processed, but only if every call to Check returned
                without throwing an exception. This method throws an exception if the
                JSON text was not accepted; in other words, the final check failed.
            */
            if (this._state != OK)
                this.OnError();

            this.Pop(Mode.Done);

            this.Push(Mode.Done);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Push(Mode mode)
        {
            /*
                Push a mode onto the stack or throw if there is overflow.
            */
            if (this._depth > 0 && this._stack.Count >= this._depth)
                this.OnError();

            this._stack.Push(mode);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Pop(Mode mode)
        {
            /*
                Pop the stack, assuring that the current mode matches the expectation.
                Throws if there is underflow or if the modes mismatch.
            */
            if (this._stack.Pop() != mode)
                this.OnError();
        }

        void OnError()
        {
            throw new Exception(string.Format("Invalid JSON text at character offset {0}.", this._offset.ToString("N0")));
        }
    }
}