namespace ConsoleApplication16
{
    static class Constants
    {
        public const string SampleXml = @"<OTA_AirDetailsRS PrimaryLangID=""eng"" Version=""1.0"" TransactionIdentifier=""014833e6050b400d9150901f0805097960900ad806095f41"" FLSNote=""This XML adds attributes not in the OTA XML spec. All such attributes start with FLS"" FLSDevice=""ota-xml-expanded"" xmlns=""http://www.opentravel.org/OTA/2003/05"">
<Success></Success>
<FLSResponseFields FLSOriginCode=""LAX"" FLSOriginName=""Los Angeles Metro"" FLSDestinationCode=""WAS"" FLSDestinationName=""Washington (ALL)"" FLSStartDate=""2013-07-08"" FLSEndDate=""2013-07-08""></FLSResponseFields>
<FlightDetails TotalFlightTime=""PT5H50M"" TotalMiles=""2425"" TotalTripTime=""PT6H55M"" FLSDepartureDateTime=""2013-07-08T01:15:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T11:10:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708AA1963/1600"">
<FlightLegDetails DepartureDateTime=""2013-07-08T01:15:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T06:15:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""1963"" JourneyDuration=""PT3H00M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 9"" FLSUUID=""LAXDFW20130708AA1963"" FLSUUIDActualFlight=""LAXDFW20130708AA1963[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DFW"" FLSLocationName=""Dallas/Fort Worth"" Terminal=""0""></ArrivalAirport>
<MarketingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""1963""></OperatingAirline>
<Equipment AirEquipType=""757""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T07:20:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T11:10:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1600"" JourneyDuration=""PT2H50M"" SequenceNumber=""2"" FLSMeals=""F"" FLSInflightServices="" 9"" FLSUUID=""DFWDCA20130708AA1600"" FLSUUIDActualFlight=""DFWDCA20130708AA1600[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""DFW"" FLSLocationName=""Dallas/Fort Worth"" Terminal=""0"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""1600""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H50M"" TotalMiles=""2425"" TotalTripTime=""PT6H55M"" FLSDepartureDateTime=""2013-07-08T01:15:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T11:10:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708BA1726/4904"">
<FlightLegDetails DepartureDateTime=""2013-07-08T01:15:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T06:15:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""1726"" JourneyDuration=""PT3H00M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXDFW20130708BA1726"" FLSUUIDActualFlight=""LAXDFW20130708BA1726[OpBy:American Airlines!AA1963]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DFW"" FLSLocationName=""Dallas/Fort Worth"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""BA"" CodeContext=""IATA"" CompanyShortName=""British Airways""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""1963""></OperatingAirline>
<Equipment AirEquipType=""757""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T07:20:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T11:10:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""4904"" JourneyDuration=""PT2H50M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""DFWDCA20130708BA4904"" FLSUUIDActualFlight=""DFWDCA20130708BA4904[OpBy:American Airlines!AA1600]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""DFW"" FLSLocationName=""Dallas/Fort Worth"" Terminal=""B"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""BA"" CodeContext=""IATA"" CompanyShortName=""British Airways""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""1600""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H55M"" TotalMiles=""2491"" TotalTripTime=""PT6H25M"" FLSDepartureDateTime=""2013-07-08T06:00:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T15:25:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708FL342/81"">
<FlightLegDetails DepartureDateTime=""2013-07-08T06:00:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T13:05:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""342"" JourneyDuration=""PT4H05M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXATL20130708FL342"" FLSUUIDActualFlight=""LAXATL20130708FL342[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""ATL"" FLSLocationName=""Atlanta"" Terminal=""N""></ArrivalAirport>
<MarketingAirline Code=""FL"" CodeContext=""IATA"" CompanyShortName=""AirTran Airways""></MarketingAirline>
<OperatingAirline Code=""FL"" CodeContext=""IATA"" CompanyShortName=""AirTran Airways"" FlightNumber=""342""></OperatingAirline>
<Equipment AirEquipType=""73G""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T13:35:00"" FLSDepartureTimeOffset=""-0400"" ArrivalDateTime=""2013-07-08T15:25:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""81"" JourneyDuration=""PT1H50M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""ATLDCA20130708FL81"" FLSUUIDActualFlight=""ATLDCA20130708FL81[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""ATL"" FLSLocationName=""Atlanta"" Terminal=""N"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""A""></ArrivalAirport>
<MarketingAirline Code=""FL"" CodeContext=""IATA"" CompanyShortName=""AirTran Airways""></MarketingAirline>
<OperatingAirline Code=""FL"" CodeContext=""IATA"" CompanyShortName=""AirTran Airways"" FlightNumber=""81""></OperatingAirline>
<Equipment AirEquipType=""717""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H55M"" TotalMiles=""2491"" TotalTripTime=""PT6H25M"" FLSDepartureDateTime=""2013-07-08T06:00:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T15:25:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708WN5342/5081"">
<FlightLegDetails DepartureDateTime=""2013-07-08T06:00:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T13:05:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""5342"" JourneyDuration=""PT4H05M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""LAXATL20130708WN5342"" FLSUUIDActualFlight=""LAXATL20130708WN5342[OpBy:AirTran Airways!FL342]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""ATL"" FLSLocationName=""Atlanta"" Terminal=""N""></ArrivalAirport>
<MarketingAirline Code=""WN"" CodeContext=""IATA"" CompanyShortName=""Southwest Airlines""></MarketingAirline>
<OperatingAirline Code=""FL"" CodeContext=""IATA"" CompanyShortName=""AirTran Airways"" FlightNumber=""342""></OperatingAirline>
<Equipment AirEquipType=""73G""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T13:35:00"" FLSDepartureTimeOffset=""-0400"" ArrivalDateTime=""2013-07-08T15:25:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""5081"" JourneyDuration=""PT1H50M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""ATLDCA20130708WN5081"" FLSUUIDActualFlight=""ATLDCA20130708WN5081[OpBy:AirTran Airways!FL81]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""ATL"" FLSLocationName=""Atlanta"" Terminal=""N"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""A""></ArrivalAirport>
<MarketingAirline Code=""WN"" CodeContext=""IATA"" CompanyShortName=""Southwest Airlines""></MarketingAirline>
<OperatingAirline Code=""FL"" CodeContext=""IATA"" CompanyShortName=""AirTran Airways"" FlightNumber=""81""></OperatingAirline>
<Equipment AirEquipType=""717""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT6H01M"" TotalMiles=""2360"" TotalTripTime=""PT6H46M"" FLSDepartureDateTime=""2013-07-08T05:45:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T15:31:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708DL1506/4310"">
<FlightLegDetails DepartureDateTime=""2013-07-08T05:45:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T13:10:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1506"" JourneyDuration=""PT4H25M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 1"" FLSUUID=""LAXDTW20130708DL1506"" FLSUUIDActualFlight=""LAXDTW20130708DL1506[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""5"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DTW"" FLSLocationName=""Detroit"" Terminal=""EM""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""1506""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T13:55:00"" FLSDepartureTimeOffset=""-0400"" ArrivalDateTime=""2013-07-08T15:31:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""4310"" JourneyDuration=""PT1H36M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""DTWIAD20130708DL4310"" FLSUUIDActualFlight=""DTWIAD20130708DL4310[Ownr:PINNACLE DBA DELTA CONNECTION!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""DTW"" FLSLocationName=""Detroit"" Terminal=""EM"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""4310""></OperatingAirline>
<Equipment AirEquipType=""CRJ""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT6H12M"" TotalMiles=""2478"" TotalTripTime=""PT6H47M"" FLSDepartureDateTime=""2013-07-08T05:45:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T15:32:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708DL2154/2015"">
<FlightLegDetails DepartureDateTime=""2013-07-08T05:45:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T13:05:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""2154"" JourneyDuration=""PT4H20M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 1"" FLSUUID=""LAXATL20130708DL2154"" FLSUUIDActualFlight=""LAXATL20130708DL2154[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""5"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""ATL"" FLSLocationName=""Atlanta"" Terminal=""S""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""2154""></OperatingAirline>
<Equipment AirEquipType=""757""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T13:40:00"" FLSDepartureTimeOffset=""-0400"" ArrivalDateTime=""2013-07-08T15:32:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""2015"" JourneyDuration=""PT1H52M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""ATLIAD20130708DL2015"" FLSUUIDActualFlight=""ATLIAD20130708DL2015[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""ATL"" FLSLocationName=""Atlanta"" Terminal=""S"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""2015""></OperatingAirline>
<Equipment AirEquipType=""M88""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT6H00M"" TotalMiles=""2440"" TotalTripTime=""PT6H43M"" FLSDepartureDateTime=""2013-07-08T06:05:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T15:48:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708DL1404/832"">
<FlightLegDetails DepartureDateTime=""2013-07-08T06:05:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T08:57:00"" FLSArrivalTimeOffset=""-0600"" FlightNumber=""1404"" JourneyDuration=""PT1H52M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""LAXSLC20130708DL1404"" FLSUUIDActualFlight=""LAXSLC20130708DL1404[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""5"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""SLC"" FLSLocationName=""Salt Lake City"" Terminal=""2""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""1404""></OperatingAirline>
<Equipment AirEquipType=""757""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T09:40:00"" FLSDepartureTimeOffset=""-0600"" ArrivalDateTime=""2013-07-08T15:48:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""832"" JourneyDuration=""PT4H08M"" SequenceNumber=""2"" FLSMeals=""F"" FLSInflightServices="" 1"" FLSUUID=""SLCDCA20130708DL832"" FLSUUIDActualFlight=""SLCDCA20130708DL832[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""SLC"" FLSLocationName=""Salt Lake City"" Terminal=""2"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""832""></OperatingAirline>
<Equipment AirEquipType=""757""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H07M"" TotalMiles=""2285"" TotalTripTime=""PT5H07M"" FLSDepartureDateTime=""2013-07-08T07:45:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T15:52:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708UA1136"">
<FlightLegDetails DepartureDateTime=""2013-07-08T07:45:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T15:52:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1136"" JourneyDuration=""PT5H07M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXIAD20130708UA1136"" FLSUUIDActualFlight=""LAXIAD20130708UA1136[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1136""></OperatingAirline>
<Equipment AirEquipType=""753""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H07M"" TotalMiles=""2285"" TotalTripTime=""PT5H07M"" FLSDepartureDateTime=""2013-07-08T07:45:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T15:52:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708NZ9104"">
<FlightLegDetails DepartureDateTime=""2013-07-08T07:45:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T15:52:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""9104"" JourneyDuration=""PT5H07M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708NZ9104"" FLSUUIDActualFlight=""LAXIAD20130708NZ9104[OpBy:United Airlines!UA1136]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""NZ"" CodeContext=""IATA"" CompanyShortName=""Air New Zealand""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1136""></OperatingAirline>
<Equipment AirEquipType=""753""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H53M"" TotalMiles=""2354"" TotalTripTime=""PT6H53M"" FLSDepartureDateTime=""2013-07-08T06:00:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T15:53:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708UA1025/624"">
<FlightLegDetails DepartureDateTime=""2013-07-08T06:00:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T12:00:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""1025"" JourneyDuration=""PT4H00M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXORD20130708UA1025"" FLSUUIDActualFlight=""LAXORD20130708UA1025[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""1""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1025""></OperatingAirline>
<Equipment AirEquipType=""73G""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T13:00:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T15:53:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""624"" JourneyDuration=""PT1H53M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""ORDDCA20130708UA624"" FLSUUIDActualFlight=""ORDDCA20130708UA624[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""624""></OperatingAirline>
<Equipment AirEquipType=""319""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H55M"" TotalMiles=""2285"" TotalTripTime=""PT4H55M"" FLSDepartureDateTime=""2013-07-08T08:00:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T15:55:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708VX108"">
<FlightLegDetails DepartureDateTime=""2013-07-08T08:00:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T15:55:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""108"" JourneyDuration=""PT4H55M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708VX108"" FLSUUIDActualFlight=""LAXIAD20130708VX108[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""3"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""VX"" CodeContext=""IATA"" CompanyShortName=""Virgin America""></MarketingAirline>
<OperatingAirline Code=""VX"" CodeContext=""IATA"" CompanyShortName=""Virgin America"" FlightNumber=""108""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H55M"" TotalMiles=""2285"" TotalTripTime=""PT4H55M"" FLSDepartureDateTime=""2013-07-08T08:00:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T15:55:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708VA6000"">
<FlightLegDetails DepartureDateTime=""2013-07-08T08:00:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T15:55:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""6000"" JourneyDuration=""PT4H55M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708VA6000"" FLSUUIDActualFlight=""LAXIAD20130708VA6000[OpBy:Virgin America!VX108]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""3"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""VA"" CodeContext=""IATA"" CompanyShortName=""Virgin Australia Intl""></MarketingAirline>
<OperatingAirline Code=""VX"" CodeContext=""IATA"" CompanyShortName=""Virgin America"" FlightNumber=""108""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H55M"" TotalMiles=""2285"" TotalTripTime=""PT4H55M"" FLSDepartureDateTime=""2013-07-08T08:00:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T15:55:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708HA2568"">
<FlightLegDetails DepartureDateTime=""2013-07-08T08:00:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T15:55:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""2568"" JourneyDuration=""PT4H55M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708HA2568"" FLSUUIDActualFlight=""LAXIAD20130708HA2568[OpBy:VIRGIN AMERICA!VX108]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""3"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""HA"" CodeContext=""IATA"" CompanyShortName=""Hawaiian Airlines""></MarketingAirline>
<OperatingAirline Code=""VX"" CodeContext=""IATA"" CompanyShortName=""Virgin America"" FlightNumber=""108""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H40M"" TotalMiles=""2326"" TotalTripTime=""PT6H25M"" FLSDepartureDateTime=""2013-07-08T06:30:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T15:55:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708WN2069/1461"">
<FlightLegDetails DepartureDateTime=""2013-07-08T06:30:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T12:25:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""2069"" JourneyDuration=""PT3H55M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""LAXMDW20130708WN2069"" FLSUUIDActualFlight=""LAXMDW20130708WN2069[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""MDW"" FLSLocationName=""Chicago Midway"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""WN"" CodeContext=""IATA"" CompanyShortName=""Southwest Airlines""></MarketingAirline>
<OperatingAirline Code=""WN"" CodeContext=""IATA"" CompanyShortName=""Southwest Airlines"" FlightNumber=""2069""></OperatingAirline>
<Equipment AirEquipType=""73H""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T13:10:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T15:55:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1461"" JourneyDuration=""PT1H45M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""MDWIAD20130708WN1461"" FLSUUIDActualFlight=""MDWIAD20130708WN1461[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""MDW"" FLSLocationName=""Chicago Midway"" Terminal="" "" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""WN"" CodeContext=""IATA"" CompanyShortName=""Southwest Airlines""></MarketingAirline>
<OperatingAirline Code=""WN"" CodeContext=""IATA"" CompanyShortName=""Southwest Airlines"" FlightNumber=""1461""></OperatingAirline>
<Equipment AirEquipType=""73W""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H45M"" TotalMiles=""2347"" TotalTripTime=""PT6H45M"" FLSDepartureDateTime=""2013-07-08T06:25:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T16:10:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Direct"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708US44"">
<FlightLegDetails DepartureDateTime=""2013-07-08T06:25:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T07:45:00"" FLSArrivalTimeOffset=""-0700"" FlightNumber=""44"" JourneyDuration=""PT1H20M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""LAXPHX20130708US44"" FLSUUIDActualFlight=""LAXPHX20130708US44[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""PHX"" FLSLocationName=""Phoenix"" Terminal=""4""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways"" FlightNumber=""44""></OperatingAirline>
<Equipment AirEquipType=""321""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T08:45:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T16:10:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""44"" JourneyDuration=""PT4H25M"" SequenceNumber=""2"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""PHXDCA20130708US44"" FLSUUIDActualFlight=""PHXDCA20130708US44[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""PHX"" FLSLocationName=""Phoenix"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""C""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways"" FlightNumber=""44""></OperatingAirline>
<Equipment AirEquipType=""321""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H05M"" TotalMiles=""2308"" TotalTripTime=""PT5H05M"" FLSDepartureDateTime=""2013-07-08T08:10:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T16:15:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708AA240"">
<FlightLegDetails DepartureDateTime=""2013-07-08T08:10:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T16:15:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""240"" JourneyDuration=""PT5H05M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 1/ 9"" FLSUUID=""LAXDCA20130708AA240"" FLSUUIDActualFlight=""LAXDCA20130708AA240[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""240""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H57M"" TotalMiles=""2465"" TotalTripTime=""PT6H35M"" FLSDepartureDateTime=""2013-07-08T06:50:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T16:25:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708DL1212/1864"">
<FlightLegDetails DepartureDateTime=""2013-07-08T06:50:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T12:22:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""1212"" JourneyDuration=""PT3H32M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 1"" FLSUUID=""LAXMSP20130708DL1212"" FLSUUIDActualFlight=""LAXMSP20130708DL1212[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""5"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""MSP"" FLSLocationName=""Minneapolis"" Terminal=""1""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""1212""></OperatingAirline>
<Equipment AirEquipType=""757""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T13:00:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T16:25:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1864"" JourneyDuration=""PT2H25M"" SequenceNumber=""2"" FLSMeals=""V"" FLSInflightServices="" "" FLSUUID=""MSPDCA20130708DL1864"" FLSUUIDActualFlight=""MSPDCA20130708DL1864[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""MSP"" FLSLocationName=""Minneapolis"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""1864""></OperatingAirline>
<Equipment AirEquipType=""M90""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H00M"" TotalMiles=""2285"" TotalTripTime=""PT5H00M"" FLSDepartureDateTime=""2013-07-08T08:35:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T16:35:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708UA1429"">
<FlightLegDetails DepartureDateTime=""2013-07-08T08:35:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T16:35:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1429"" JourneyDuration=""PT5H00M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXIAD20130708UA1429"" FLSUUIDActualFlight=""LAXIAD20130708UA1429[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1429""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H00M"" TotalMiles=""2285"" TotalTripTime=""PT5H00M"" FLSDepartureDateTime=""2013-07-08T08:35:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T16:35:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708NZ9168"">
<FlightLegDetails DepartureDateTime=""2013-07-08T08:35:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T16:35:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""9168"" JourneyDuration=""PT5H00M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708NZ9168"" FLSUUIDActualFlight=""LAXIAD20130708NZ9168[OpBy:United Airlines!UA1429]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""NZ"" CodeContext=""IATA"" CompanyShortName=""Air New Zealand""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1429""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H46M"" TotalMiles=""2312"" TotalTripTime=""PT6H35M"" FLSDepartureDateTime=""2013-07-08T07:00:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T16:35:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708UA495/948"">
<FlightLegDetails DepartureDateTime=""2013-07-08T07:00:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T10:25:00"" FLSArrivalTimeOffset=""-0600"" FlightNumber=""495"" JourneyDuration=""PT2H25M"" SequenceNumber=""1"" FLSMeals=""G"" FLSInflightServices="" "" FLSUUID=""LAXDEN20130708UA495"" FLSUUIDActualFlight=""LAXDEN20130708UA495[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DEN"" FLSLocationName=""Denver"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""495""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T11:14:00"" FLSDepartureTimeOffset=""-0600"" ArrivalDateTime=""2013-07-08T16:35:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""948"" JourneyDuration=""PT3H21M"" SequenceNumber=""2"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""DENIAD20130708UA948"" FLSUUIDActualFlight=""DENIAD20130708UA948[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""DEN"" FLSLocationName=""Denver"" Terminal="" "" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""948""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H46M"" TotalMiles=""2312"" TotalTripTime=""PT6H35M"" FLSDepartureDateTime=""2013-07-08T07:00:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T16:35:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708US6166/6254"">
<FlightLegDetails DepartureDateTime=""2013-07-08T07:00:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T10:25:00"" FLSArrivalTimeOffset=""-0600"" FlightNumber=""6166"" JourneyDuration=""PT2H25M"" SequenceNumber=""1"" FLSMeals=""G"" FLSInflightServices="" "" FLSUUID=""LAXDEN20130708US6166"" FLSUUIDActualFlight=""LAXDEN20130708US6166[OpBy:United Airlines!UA495]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DEN"" FLSLocationName=""Denver"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""495""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T11:14:00"" FLSDepartureTimeOffset=""-0600"" ArrivalDateTime=""2013-07-08T16:35:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""6254"" JourneyDuration=""PT3H21M"" SequenceNumber=""2"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""DENIAD20130708US6254"" FLSUUIDActualFlight=""DENIAD20130708US6254[OpBy:United Airlines!UA948]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""DEN"" FLSLocationName=""Denver"" Terminal="" "" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""948""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H55M"" TotalMiles=""2285"" TotalTripTime=""PT4H55M"" FLSDepartureDateTime=""2013-07-08T09:15:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T17:10:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708AA76"">
<FlightLegDetails DepartureDateTime=""2013-07-08T09:15:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T17:10:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""76"" JourneyDuration=""PT4H55M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 1/ 9"" FLSUUID=""LAXIAD20130708AA76"" FLSUUIDActualFlight=""LAXIAD20130708AA76[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""76""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H55M"" TotalMiles=""2285"" TotalTripTime=""PT4H55M"" FLSDepartureDateTime=""2013-07-08T09:15:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T17:10:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708QF3085"">
<FlightLegDetails DepartureDateTime=""2013-07-08T09:15:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T17:10:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""3085"" JourneyDuration=""PT4H55M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708QF3085"" FLSUUIDActualFlight=""LAXIAD20130708QF3085[OpBy:American Airlines!AA76]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""QF"" CodeContext=""IATA"" CompanyShortName=""Qantas Airways""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""76""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H55M"" TotalMiles=""2285"" TotalTripTime=""PT4H55M"" FLSDepartureDateTime=""2013-07-08T09:15:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T17:10:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708BA2491"">
<FlightLegDetails DepartureDateTime=""2013-07-08T09:15:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T17:10:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""2491"" JourneyDuration=""PT4H55M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708BA2491"" FLSUUIDActualFlight=""LAXIAD20130708BA2491[OpBy:American Airlines!AA76]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""BA"" CodeContext=""IATA"" CompanyShortName=""British Airways""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""76""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H53M"" TotalMiles=""2309"" TotalTripTime=""PT6H23M"" FLSDepartureDateTime=""2013-07-08T08:15:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T17:38:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708DL1760/5587"">
<FlightLegDetails DepartureDateTime=""2013-07-08T08:15:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T15:30:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1760"" JourneyDuration=""PT4H15M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXCVG20130708DL1760"" FLSUUIDActualFlight=""LAXCVG20130708DL1760[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""5"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""CVG"" FLSLocationName=""Cincinnati"" Terminal=""3""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""1760""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T16:00:00"" FLSDepartureTimeOffset=""-0400"" ArrivalDateTime=""2013-07-08T17:38:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""5587"" JourneyDuration=""PT1H38M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""CVGDCA20130708DL5587"" FLSUUIDActualFlight=""CVGDCA20130708DL5587[Ownr:EXPRESSJET DBA DELTA CONNECTION!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""CVG"" FLSLocationName=""Cincinnati"" Terminal=""3"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""5587""></OperatingAirline>
<Equipment AirEquipType=""CR9""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H45M"" TotalMiles=""2326"" TotalTripTime=""PT6H20M"" FLSDepartureDateTime=""2013-07-08T08:20:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T17:40:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Direct"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708WN3851"">
<FlightLegDetails DepartureDateTime=""2013-07-08T08:20:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T14:20:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""3851"" JourneyDuration=""PT4H00M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""LAXMDW20130708WN3851"" FLSUUIDActualFlight=""LAXMDW20130708WN3851[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""MDW"" FLSLocationName=""Chicago Midway"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""WN"" CodeContext=""IATA"" CompanyShortName=""Southwest Airlines""></MarketingAirline>
<OperatingAirline Code=""WN"" CodeContext=""IATA"" CompanyShortName=""Southwest Airlines"" FlightNumber=""3851""></OperatingAirline>
<Equipment AirEquipType=""73W""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T14:55:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T17:40:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""3851"" JourneyDuration=""PT1H45M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""MDWIAD20130708WN3851"" FLSUUIDActualFlight=""MDWIAD20130708WN3851[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""MDW"" FLSLocationName=""Chicago Midway"" Terminal="" "" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""WN"" CodeContext=""IATA"" CompanyShortName=""Southwest Airlines""></MarketingAirline>
<OperatingAirline Code=""WN"" CodeContext=""IATA"" CompanyShortName=""Southwest Airlines"" FlightNumber=""3851""></OperatingAirline>
<Equipment AirEquipType=""73W""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H47M"" TotalMiles=""2312"" TotalTripTime=""PT6H34M"" FLSDepartureDateTime=""2013-07-08T08:15:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T17:49:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708US6246/6128"">
<FlightLegDetails DepartureDateTime=""2013-07-08T08:15:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T11:41:00"" FLSArrivalTimeOffset=""-0600"" FlightNumber=""6246"" JourneyDuration=""PT2H26M"" SequenceNumber=""1"" FLSMeals=""G"" FLSInflightServices="" "" FLSUUID=""LAXDEN20130708US6246"" FLSUUIDActualFlight=""LAXDEN20130708US6246[OpBy:United Airlines!UA452]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DEN"" FLSLocationName=""Denver"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""452""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T12:28:00"" FLSDepartureTimeOffset=""-0600"" ArrivalDateTime=""2013-07-08T17:49:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""6128"" JourneyDuration=""PT3H21M"" SequenceNumber=""2"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""DENIAD20130708US6128"" FLSUUIDActualFlight=""DENIAD20130708US6128[OpBy:United Airlines!UA452]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""DEN"" FLSLocationName=""Denver"" Terminal="" "" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""452""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT6H05M"" TotalMiles=""2425"" TotalTripTime=""PT6H55M"" FLSDepartureDateTime=""2013-07-08T08:00:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T17:55:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708AA2428/2286"">
<FlightLegDetails DepartureDateTime=""2013-07-08T08:00:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T13:05:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""2428"" JourneyDuration=""PT3H05M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 9"" FLSUUID=""LAXDFW20130708AA2428"" FLSUUIDActualFlight=""LAXDFW20130708AA2428[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DFW"" FLSLocationName=""Dallas/Fort Worth"" Terminal=""0""></ArrivalAirport>
<MarketingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""2428""></OperatingAirline>
<Equipment AirEquipType=""763""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T13:55:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T17:55:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""2286"" JourneyDuration=""PT3H00M"" SequenceNumber=""2"" FLSMeals=""F"" FLSInflightServices="" 9"" FLSUUID=""DFWDCA20130708AA2286"" FLSUUIDActualFlight=""DFWDCA20130708AA2286[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""DFW"" FLSLocationName=""Dallas/Fort Worth"" Terminal=""0"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""2286""></OperatingAirline>
<Equipment AirEquipType=""M80""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H06M"" TotalMiles=""2285"" TotalTripTime=""PT5H06M"" FLSDepartureDateTime=""2013-07-08T09:56:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T18:02:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708UA1471"">
<FlightLegDetails DepartureDateTime=""2013-07-08T09:56:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T18:02:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1471"" JourneyDuration=""PT5H06M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXIAD20130708UA1471"" FLSUUIDActualFlight=""LAXIAD20130708UA1471[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1471""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H06M"" TotalMiles=""2285"" TotalTripTime=""PT5H06M"" FLSDepartureDateTime=""2013-07-08T09:56:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T18:02:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708NZ9106"">
<FlightLegDetails DepartureDateTime=""2013-07-08T09:56:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T18:02:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""9106"" JourneyDuration=""PT5H06M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708NZ9106"" FLSUUIDActualFlight=""LAXIAD20130708NZ9106[OpBy:United Airlines!UA1471]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""NZ"" CodeContext=""IATA"" CompanyShortName=""Air New Zealand""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1471""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT6H12M"" TotalMiles=""2518"" TotalTripTime=""PT6H42M"" FLSDepartureDateTime=""2013-07-08T08:28:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T18:10:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708US716/1461"">
<FlightLegDetails DepartureDateTime=""2013-07-08T08:28:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T16:45:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""716"" JourneyDuration=""PT5H17M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXPHL20130708US716"" FLSUUIDActualFlight=""LAXPHL20130708US716[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""PHL"" FLSLocationName=""Philadelphia"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways"" FlightNumber=""716""></OperatingAirline>
<Equipment AirEquipType=""321""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T17:15:00"" FLSDepartureTimeOffset=""-0400"" ArrivalDateTime=""2013-07-08T18:10:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1461"" JourneyDuration=""PT0H55M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""PHLDCA20130708US1461"" FLSUUIDActualFlight=""PHLDCA20130708US1461[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""PHL"" FLSLocationName=""Philadelphia"" Terminal=""B"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""C""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways"" FlightNumber=""1461""></OperatingAirline>
<Equipment AirEquipType=""319""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT6H00M"" TotalMiles=""2405"" TotalTripTime=""PT6H50M"" FLSDepartureDateTime=""2013-07-08T08:30:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T18:20:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708AA2430/1720"">
<FlightLegDetails DepartureDateTime=""2013-07-08T08:30:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T13:35:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""2430"" JourneyDuration=""PT3H05M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 9"" FLSUUID=""LAXDFW20130708AA2430"" FLSUUIDActualFlight=""LAXDFW20130708AA2430[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DFW"" FLSLocationName=""Dallas/Fort Worth"" Terminal=""0""></ArrivalAirport>
<MarketingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""2430""></OperatingAirline>
<Equipment AirEquipType=""757""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T14:25:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T18:20:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1720"" JourneyDuration=""PT2H55M"" SequenceNumber=""2"" FLSMeals=""F"" FLSInflightServices="" 9"" FLSUUID=""DFWIAD20130708AA1720"" FLSUUIDActualFlight=""DFWIAD20130708AA1720[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""DFW"" FLSLocationName=""Dallas/Fort Worth"" Terminal=""0"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""1720""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT6H00M"" TotalMiles=""2405"" TotalTripTime=""PT6H50M"" FLSDepartureDateTime=""2013-07-08T08:30:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T18:20:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708QF3202/4590"">
<FlightLegDetails DepartureDateTime=""2013-07-08T08:30:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T13:35:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""3202"" JourneyDuration=""PT3H05M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 9"" FLSUUID=""LAXDFW20130708QF3202"" FLSUUIDActualFlight=""LAXDFW20130708QF3202[OpBy:American Airlines!AA2430]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DFW"" FLSLocationName=""Dallas/Fort Worth"" Terminal=""0""></ArrivalAirport>
<MarketingAirline Code=""QF"" CodeContext=""IATA"" CompanyShortName=""Qantas Airways""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""2430""></OperatingAirline>
<Equipment AirEquipType=""757""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T14:25:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T18:20:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""4590"" JourneyDuration=""PT2H55M"" SequenceNumber=""2"" FLSMeals=""F"" FLSInflightServices="" 9"" FLSUUID=""DFWIAD20130708QF4590"" FLSUUIDActualFlight=""DFWIAD20130708QF4590[OpBy:American Airlines!AA1720]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""DFW"" FLSLocationName=""Dallas/Fort Worth"" Terminal=""0"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""QF"" CodeContext=""IATA"" CompanyShortName=""Qantas Airways""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""1720""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H55M"" TotalMiles=""2285"" TotalTripTime=""PT4H55M"" FLSDepartureDateTime=""2013-07-08T10:55:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T18:50:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708VX112"">
<FlightLegDetails DepartureDateTime=""2013-07-08T10:55:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T18:50:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""112"" JourneyDuration=""PT4H55M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708VX112"" FLSUUIDActualFlight=""LAXIAD20130708VX112[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""3"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""VX"" CodeContext=""IATA"" CompanyShortName=""Virgin America""></MarketingAirline>
<OperatingAirline Code=""VX"" CodeContext=""IATA"" CompanyShortName=""Virgin America"" FlightNumber=""112""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H55M"" TotalMiles=""2285"" TotalTripTime=""PT4H55M"" FLSDepartureDateTime=""2013-07-08T10:55:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T18:50:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708VA6002"">
<FlightLegDetails DepartureDateTime=""2013-07-08T10:55:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T18:50:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""6002"" JourneyDuration=""PT4H55M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708VA6002"" FLSUUIDActualFlight=""LAXIAD20130708VA6002[OpBy:Virgin America!VX112]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""3"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""VA"" CodeContext=""IATA"" CompanyShortName=""Virgin Australia Intl""></MarketingAirline>
<OperatingAirline Code=""VX"" CodeContext=""IATA"" CompanyShortName=""Virgin America"" FlightNumber=""112""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H55M"" TotalMiles=""2285"" TotalTripTime=""PT4H55M"" FLSDepartureDateTime=""2013-07-08T10:55:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T18:50:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708HA2530"">
<FlightLegDetails DepartureDateTime=""2013-07-08T10:55:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T18:50:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""2530"" JourneyDuration=""PT4H55M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708HA2530"" FLSUUIDActualFlight=""LAXIAD20130708HA2530[OpBy:VIRGIN AMERICA!VX112]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""3"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""HA"" CodeContext=""IATA"" CompanyShortName=""Hawaiian Airlines""></MarketingAirline>
<OperatingAirline Code=""VX"" CodeContext=""IATA"" CompanyShortName=""Virgin America"" FlightNumber=""112""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT6H07M"" TotalMiles=""2360"" TotalTripTime=""PT6H42M"" FLSDepartureDateTime=""2013-07-08T09:20:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T19:02:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708DL1806/3444"">
<FlightLegDetails DepartureDateTime=""2013-07-08T09:20:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T16:50:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1806"" JourneyDuration=""PT4H30M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 1"" FLSUUID=""LAXDTW20130708DL1806"" FLSUUIDActualFlight=""LAXDTW20130708DL1806[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""5"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DTW"" FLSLocationName=""Detroit"" Terminal=""EM""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""1806""></OperatingAirline>
<Equipment AirEquipType=""763""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T17:25:00"" FLSDepartureTimeOffset=""-0400"" ArrivalDateTime=""2013-07-08T19:02:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""3444"" JourneyDuration=""PT1H37M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""DTWIAD20130708DL3444"" FLSUUIDActualFlight=""DTWIAD20130708DL3444[Ownr:PINNACLE DBA DELTA CONNECTION!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""DTW"" FLSLocationName=""Detroit"" Terminal=""EM"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""3444""></OperatingAirline>
<Equipment AirEquipType=""CRJ""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H41M"" TotalMiles=""2347"" TotalTripTime=""PT6H39M"" FLSDepartureDateTime=""2013-07-08T10:05:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T19:44:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708US488/42"">
<FlightLegDetails DepartureDateTime=""2013-07-08T10:05:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T11:22:00"" FLSArrivalTimeOffset=""-0700"" FlightNumber=""488"" JourneyDuration=""PT1H17M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""LAXPHX20130708US488"" FLSUUIDActualFlight=""LAXPHX20130708US488[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""PHX"" FLSLocationName=""Phoenix"" Terminal=""4""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways"" FlightNumber=""488""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T12:20:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T19:44:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""42"" JourneyDuration=""PT4H24M"" SequenceNumber=""2"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""PHXDCA20130708US42"" FLSUUIDActualFlight=""PHXDCA20130708US42[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""PHX"" FLSLocationName=""Phoenix"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""C""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways"" FlightNumber=""42""></OperatingAirline>
<Equipment AirEquipType=""321""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H56M"" TotalMiles=""2354"" TotalTripTime=""PT6H53M"" FLSDepartureDateTime=""2013-07-08T10:04:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T19:57:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708US6663/7998"">
<FlightLegDetails DepartureDateTime=""2013-07-08T10:04:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T16:05:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""6663"" JourneyDuration=""PT4H01M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXORD20130708US6663"" FLSUUIDActualFlight=""LAXORD20130708US6663[OpBy:United Airlines!UA478]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""1""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""478""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T17:02:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T19:57:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""7998"" JourneyDuration=""PT1H55M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""ORDDCA20130708US7998"" FLSUUIDActualFlight=""ORDDCA20130708US7998[OpBy:SHUTTLE AMERICA DBA UNITED EXPRESS!UA3445]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""3445""></OperatingAirline>
<Equipment AirEquipType=""E70""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H56M"" TotalMiles=""2354"" TotalTripTime=""PT6H53M"" FLSDepartureDateTime=""2013-07-08T10:04:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T19:57:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708UA478/3445"">
<FlightLegDetails DepartureDateTime=""2013-07-08T10:04:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T16:05:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""478"" JourneyDuration=""PT4H01M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXORD20130708UA478"" FLSUUIDActualFlight=""LAXORD20130708UA478[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""1""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""478""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T17:02:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T19:57:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""3445"" JourneyDuration=""PT1H55M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""ORDDCA20130708UA3445"" FLSUUIDActualFlight=""ORDDCA20130708UA3445[Ownr:SHUTTLE AMERICA DBA UNITED EXPRESS!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""3445""></OperatingAirline>
<Equipment AirEquipType=""E70""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H55M"" TotalMiles=""2354"" TotalTripTime=""PT6H45M"" FLSDepartureDateTime=""2013-07-08T10:15:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T20:00:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Direct"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708AA1894"">
<FlightLegDetails DepartureDateTime=""2013-07-08T10:15:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T16:15:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""1894"" JourneyDuration=""PT4H00M"" SequenceNumber=""1"" FLSMeals=""G"" FLSInflightServices="" 1/ 9"" FLSUUID=""LAXORD20130708AA1894"" FLSUUIDActualFlight=""LAXORD20130708AA1894[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""3""></ArrivalAirport>
<MarketingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""1894""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T17:05:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T20:00:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1894"" JourneyDuration=""PT1H55M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""ORDDCA20130708AA1894"" FLSUUIDActualFlight=""ORDDCA20130708AA1894[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""3"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""1894""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H55M"" TotalMiles=""2354"" TotalTripTime=""PT6H45M"" FLSDepartureDateTime=""2013-07-08T10:15:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T20:00:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708BA4365/4900"">
<FlightLegDetails DepartureDateTime=""2013-07-08T10:15:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T16:15:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""4365"" JourneyDuration=""PT4H00M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXORD20130708BA4365"" FLSUUIDActualFlight=""LAXORD20130708BA4365[OpBy:American Airlines!AA1894]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""3""></ArrivalAirport>
<MarketingAirline Code=""BA"" CodeContext=""IATA"" CompanyShortName=""British Airways""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""1894""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T17:05:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T20:00:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""4900"" JourneyDuration=""PT1H55M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""ORDDCA20130708BA4900"" FLSUUIDActualFlight=""ORDDCA20130708BA4900[OpBy:American Airlines!AA1894]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""3"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""BA"" CodeContext=""IATA"" CompanyShortName=""British Airways""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""1894""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT6H01M"" TotalMiles=""2339"" TotalTripTime=""PT6H49M"" FLSDepartureDateTime=""2013-07-08T10:52:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T20:41:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708UA1665/3895"">
<FlightLegDetails DepartureDateTime=""2013-07-08T10:52:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T18:24:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1665"" JourneyDuration=""PT4H32M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXCLE20130708UA1665"" FLSUUIDActualFlight=""LAXCLE20130708UA1665[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""CLE"" FLSLocationName=""Cleveland"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1665""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T19:12:00"" FLSDepartureTimeOffset=""-0400"" ArrivalDateTime=""2013-07-08T20:41:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""3895"" JourneyDuration=""PT1H29M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""CLEIAD20130708UA3895"" FLSUUIDActualFlight=""CLEIAD20130708UA3895[Ownr:REPUBLIC AIRLINES DBA UNITED EXPRESS!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""CLE"" FLSLocationName=""Cleveland"" Terminal="" "" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""3895""></OperatingAirline>
<Equipment AirEquipType=""DH4""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H17M"" TotalMiles=""2308"" TotalTripTime=""PT5H17M"" FLSDepartureDateTime=""2013-07-08T12:40:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T20:57:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708AS6"">
<FlightLegDetails DepartureDateTime=""2013-07-08T12:40:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T20:57:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""6"" JourneyDuration=""PT5H17M"" SequenceNumber=""1"" FLSMeals=""FF"" FLSInflightServices="" 9"" FLSUUID=""LAXDCA20130708AS6"" FLSUUIDActualFlight=""LAXDCA20130708AS6[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""6"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""AS"" CodeContext=""IATA"" CompanyShortName=""Alaska Airlines""></MarketingAirline>
<OperatingAirline Code=""AS"" CodeContext=""IATA"" CompanyShortName=""Alaska Airlines"" FlightNumber=""6""></OperatingAirline>
<Equipment AirEquipType=""73H""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H17M"" TotalMiles=""2308"" TotalTripTime=""PT5H17M"" FLSDepartureDateTime=""2013-07-08T12:40:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T20:57:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708KE6081"">
<FlightLegDetails DepartureDateTime=""2013-07-08T12:40:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T20:57:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""6081"" JourneyDuration=""PT5H17M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""LAXDCA20130708KE6081"" FLSUUIDActualFlight=""LAXDCA20130708KE6081[OpBy:Alaska Airlines!AS6]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""6"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""KE"" CodeContext=""IATA"" CompanyShortName=""Korean Air""></MarketingAirline>
<OperatingAirline Code=""AS"" CodeContext=""IATA"" CompanyShortName=""Alaska Airlines"" FlightNumber=""6""></OperatingAirline>
<Equipment AirEquipType=""73H""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H17M"" TotalMiles=""2308"" TotalTripTime=""PT5H17M"" FLSDepartureDateTime=""2013-07-08T12:40:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T20:57:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708DL7473"">
<FlightLegDetails DepartureDateTime=""2013-07-08T12:40:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T20:57:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""7473"" JourneyDuration=""PT5H17M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 9"" FLSUUID=""LAXDCA20130708DL7473"" FLSUUIDActualFlight=""LAXDCA20130708DL7473[OpBy:Alaska Airlines!AS6]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""6"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""AS"" CodeContext=""IATA"" CompanyShortName=""Alaska Airlines"" FlightNumber=""6""></OperatingAirline>
<Equipment AirEquipType=""73H""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H17M"" TotalMiles=""2308"" TotalTripTime=""PT5H17M"" FLSDepartureDateTime=""2013-07-08T12:40:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T20:57:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708AA7076"">
<FlightLegDetails DepartureDateTime=""2013-07-08T12:40:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T20:57:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""7076"" JourneyDuration=""PT5H17M"" SequenceNumber=""1"" FLSMeals=""FF"" FLSInflightServices="" 9"" FLSUUID=""LAXDCA20130708AA7076"" FLSUUIDActualFlight=""LAXDCA20130708AA7076[OpBy:Alaska Airlines!AS6]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""6"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines""></MarketingAirline>
<OperatingAirline Code=""AS"" CodeContext=""IATA"" CompanyShortName=""Alaska Airlines"" FlightNumber=""6""></OperatingAirline>
<Equipment AirEquipType=""737""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H53M"" TotalMiles=""2354"" TotalTripTime=""PT6H36M"" FLSDepartureDateTime=""2013-07-08T11:23:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T20:59:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708UA1126/1481"">
<FlightLegDetails DepartureDateTime=""2013-07-08T11:23:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T17:20:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""1126"" JourneyDuration=""PT3H57M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXORD20130708UA1126"" FLSUUIDActualFlight=""LAXORD20130708UA1126[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""1""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1126""></OperatingAirline>
<Equipment AirEquipType=""753""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T18:03:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T20:59:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1481"" JourneyDuration=""PT1H56M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""ORDDCA20130708UA1481"" FLSUUIDActualFlight=""ORDDCA20130708UA1481[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1481""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H44M"" TotalMiles=""2316"" TotalTripTime=""PT6H50M"" FLSDepartureDateTime=""2013-07-08T11:11:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T21:01:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708US6318/7395"">
<FlightLegDetails DepartureDateTime=""2013-07-08T11:11:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T18:47:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""6318"" JourneyDuration=""PT4H36M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXPIT20130708US6318"" FLSUUIDActualFlight=""LAXPIT20130708US6318[OpBy:United Airlines!UA458]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""PIT"" FLSLocationName=""Pittsburgh"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""458""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T19:53:00"" FLSDepartureTimeOffset=""-0400"" ArrivalDateTime=""2013-07-08T21:01:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""7395"" JourneyDuration=""PT1H08M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""PITIAD20130708US7395"" FLSUUIDActualFlight=""PITIAD20130708US7395[OpBy:EXPRESSJET AIRLINES DBA UNITED EXPRESS!UA3814]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""PIT"" FLSLocationName=""Pittsburgh"" Terminal="" "" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""3814""></OperatingAirline>
<Equipment AirEquipType=""ERJ""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H44M"" TotalMiles=""2316"" TotalTripTime=""PT6H50M"" FLSDepartureDateTime=""2013-07-08T11:11:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T21:01:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708UA458/3814"">
<FlightLegDetails DepartureDateTime=""2013-07-08T11:11:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T18:47:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""458"" JourneyDuration=""PT4H36M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXPIT20130708UA458"" FLSUUIDActualFlight=""LAXPIT20130708UA458[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""PIT"" FLSLocationName=""Pittsburgh"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""458""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T19:53:00"" FLSDepartureTimeOffset=""-0400"" ArrivalDateTime=""2013-07-08T21:01:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""3814"" JourneyDuration=""PT1H08M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""PITIAD20130708UA3814"" FLSUUIDActualFlight=""PITIAD20130708UA3814[Ownr:EXPRESSJET AIRLINES DBA UNITED EXPRESS!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""PIT"" FLSLocationName=""Pittsburgh"" Terminal="" "" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""3814""></OperatingAirline>
<Equipment AirEquipType=""ERJ""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H47M"" TotalMiles=""2331"" TotalTripTime=""PT6H41M"" FLSDepartureDateTime=""2013-07-08T11:23:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T21:04:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708UA1126/1655"">
<FlightLegDetails DepartureDateTime=""2013-07-08T11:23:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T17:20:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""1126"" JourneyDuration=""PT3H57M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXORD20130708UA1126"" FLSUUIDActualFlight=""LAXORD20130708UA1126[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""1""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1126""></OperatingAirline>
<Equipment AirEquipType=""753""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T18:14:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T21:04:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1655"" JourneyDuration=""PT1H50M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""ORDIAD20130708UA1655"" FLSUUIDActualFlight=""ORDIAD20130708UA1655[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1655""></OperatingAirline>
<Equipment AirEquipType=""739""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H55M"" TotalMiles=""2285"" TotalTripTime=""PT4H55M"" FLSDepartureDateTime=""2013-07-08T13:12:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T21:07:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708UA653"">
<FlightLegDetails DepartureDateTime=""2013-07-08T13:12:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T21:07:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""653"" JourneyDuration=""PT4H55M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXIAD20130708UA653"" FLSUUIDActualFlight=""LAXIAD20130708UA653[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""653""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H55M"" TotalMiles=""2285"" TotalTripTime=""PT4H55M"" FLSDepartureDateTime=""2013-07-08T13:12:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T21:07:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708US6762"">
<FlightLegDetails DepartureDateTime=""2013-07-08T13:12:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T21:07:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""6762"" JourneyDuration=""PT4H55M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXIAD20130708US6762"" FLSUUIDActualFlight=""LAXIAD20130708US6762[OpBy:United Airlines!UA653]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""653""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H55M"" TotalMiles=""2285"" TotalTripTime=""PT4H55M"" FLSDepartureDateTime=""2013-07-08T13:12:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T21:07:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708NZ9110"">
<FlightLegDetails DepartureDateTime=""2013-07-08T13:12:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T21:07:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""9110"" JourneyDuration=""PT4H55M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708NZ9110"" FLSUUIDActualFlight=""LAXIAD20130708NZ9110[OpBy:United Airlines!UA653]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""NZ"" CodeContext=""IATA"" CompanyShortName=""Air New Zealand""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""653""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H55M"" TotalMiles=""2285"" TotalTripTime=""PT4H55M"" FLSDepartureDateTime=""2013-07-08T13:12:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T21:07:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708CA7263"">
<FlightLegDetails DepartureDateTime=""2013-07-08T13:12:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T21:07:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""7263"" JourneyDuration=""PT4H55M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXIAD20130708CA7263"" FLSUUIDActualFlight=""LAXIAD20130708CA7263[OpBy:United Airlines!UA653]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""CA"" CodeContext=""IATA"" CompanyShortName=""Air China""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""653""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H54M"" TotalMiles=""2360"" TotalTripTime=""PT6H39M"" FLSDepartureDateTime=""2013-07-08T11:33:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T21:12:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708UA6325/1043"">
<FlightLegDetails DepartureDateTime=""2013-07-08T11:33:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T12:29:00"" FLSArrivalTimeOffset=""-0700"" FlightNumber=""6325"" JourneyDuration=""PT0H56M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""LAXSAN20130708UA6325"" FLSUUIDActualFlight=""LAXSAN20130708UA6325[Ownr:SKYWEST DBA UNITED EXPRESS!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""8"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""SAN"" FLSLocationName=""San Diego"" Terminal=""R""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""6325""></OperatingAirline>
<Equipment AirEquipType=""EM2""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T13:14:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T21:12:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1043"" JourneyDuration=""PT4H58M"" SequenceNumber=""2"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""SANIAD20130708UA1043"" FLSUUIDActualFlight=""SANIAD20130708UA1043[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""SAN"" FLSLocationName=""San Diego"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1043""></OperatingAirline>
<Equipment AirEquipType=""73G""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT6H02M"" TotalMiles=""2454"" TotalTripTime=""PT6H52M"" FLSDepartureDateTime=""2013-07-08T11:20:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T21:12:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708US1124/1056"">
<FlightLegDetails DepartureDateTime=""2013-07-08T11:20:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T19:05:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1124"" JourneyDuration=""PT4H45M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXCLT20130708US1124"" FLSUUIDActualFlight=""LAXCLT20130708US1124[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""CLT"" FLSLocationName=""Charlotte"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways"" FlightNumber=""1124""></OperatingAirline>
<Equipment AirEquipType=""321""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T19:55:00"" FLSDepartureTimeOffset=""-0400"" ArrivalDateTime=""2013-07-08T21:12:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1056"" JourneyDuration=""PT1H17M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""CLTDCA20130708US1056"" FLSUUIDActualFlight=""CLTDCA20130708US1056[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""CLT"" FLSLocationName=""Charlotte"" Terminal="" "" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""C""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways"" FlightNumber=""1056""></OperatingAirline>
<Equipment AirEquipType=""319""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT6H00M"" TotalMiles=""2382"" TotalTripTime=""PT6H50M"" FLSDepartureDateTime=""2013-07-08T11:30:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T21:20:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708DL1706/188"">
<FlightLegDetails DepartureDateTime=""2013-07-08T11:30:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T19:00:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1706"" JourneyDuration=""PT4H30M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 1"" FLSUUID=""LAXDTW20130708DL1706"" FLSUUIDActualFlight=""LAXDTW20130708DL1706[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""5"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DTW"" FLSLocationName=""Detroit"" Terminal=""EM""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""1706""></OperatingAirline>
<Equipment AirEquipType=""763""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T19:50:00"" FLSDepartureTimeOffset=""-0400"" ArrivalDateTime=""2013-07-08T21:20:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""188"" JourneyDuration=""PT1H30M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""DTWDCA20130708DL188"" FLSUUIDActualFlight=""DTWDCA20130708DL188[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""DTW"" FLSLocationName=""Detroit"" Terminal=""EM"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""188""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H49M"" TotalMiles=""2354"" TotalTripTime=""PT6H40M"" FLSDepartureDateTime=""2013-07-08T12:16:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T21:56:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708UA884/1101"">
<FlightLegDetails DepartureDateTime=""2013-07-08T12:16:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T18:14:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""884"" JourneyDuration=""PT3H58M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXORD20130708UA884"" FLSUUIDActualFlight=""LAXORD20130708UA884[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""1""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""884""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T19:05:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T21:56:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1101"" JourneyDuration=""PT1H51M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""ORDDCA20130708UA1101"" FLSUUIDActualFlight=""ORDDCA20130708UA1101[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1101""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H37M"" TotalMiles=""2347"" TotalTripTime=""PT6H14M"" FLSDepartureDateTime=""2013-07-08T12:45:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T21:59:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708US7/46"">
<FlightLegDetails DepartureDateTime=""2013-07-08T12:45:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T14:08:00"" FLSArrivalTimeOffset=""-0700"" FlightNumber=""7"" JourneyDuration=""PT1H23M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""LAXPHX20130708US7"" FLSUUIDActualFlight=""LAXPHX20130708US7[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""PHX"" FLSLocationName=""Phoenix"" Terminal=""4""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways"" FlightNumber=""7""></OperatingAirline>
<Equipment AirEquipType=""321""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T14:45:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T21:59:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""46"" JourneyDuration=""PT4H14M"" SequenceNumber=""2"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""PHXDCA20130708US46"" FLSUUIDActualFlight=""PHXDCA20130708US46[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""PHX"" FLSLocationName=""Phoenix"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""C""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways"" FlightNumber=""46""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H50M"" TotalMiles=""2285"" TotalTripTime=""PT4H50M"" FLSDepartureDateTime=""2013-07-08T14:40:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T22:30:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708AA144"">
<FlightLegDetails DepartureDateTime=""2013-07-08T14:40:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T22:30:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""144"" JourneyDuration=""PT4H50M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 1/ 9"" FLSUUID=""LAXIAD20130708AA144"" FLSUUIDActualFlight=""LAXIAD20130708AA144[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""144""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H50M"" TotalMiles=""2285"" TotalTripTime=""PT4H50M"" FLSDepartureDateTime=""2013-07-08T14:40:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T22:30:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708TN1220"">
<FlightLegDetails DepartureDateTime=""2013-07-08T14:40:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T22:30:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1220"" JourneyDuration=""PT4H50M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 1/ 9"" FLSUUID=""LAXIAD20130708TN1220"" FLSUUIDActualFlight=""LAXIAD20130708TN1220[OpBy:American Airlines!AA144]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""TN"" CodeContext=""IATA"" CompanyShortName=""Air Tahiti Nui""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""144""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H50M"" TotalMiles=""2285"" TotalTripTime=""PT4H50M"" FLSDepartureDateTime=""2013-07-08T14:40:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T22:30:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708QF3003"">
<FlightLegDetails DepartureDateTime=""2013-07-08T14:40:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T22:30:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""3003"" JourneyDuration=""PT4H50M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708QF3003"" FLSUUIDActualFlight=""LAXIAD20130708QF3003[OpBy:American Airlines!AA144]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""QF"" CodeContext=""IATA"" CompanyShortName=""Qantas Airways""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""144""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H50M"" TotalMiles=""2285"" TotalTripTime=""PT4H50M"" FLSDepartureDateTime=""2013-07-08T14:40:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T22:30:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708JL7510"">
<FlightLegDetails DepartureDateTime=""2013-07-08T14:40:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T22:30:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""7510"" JourneyDuration=""PT4H50M"" SequenceNumber=""1"" FLSMeals=""D"" FLSInflightServices="" 1/ 9"" FLSUUID=""LAXIAD20130708JL7510"" FLSUUIDActualFlight=""LAXIAD20130708JL7510[OpBy:American Airlines!AA144]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""JL"" CodeContext=""IATA"" CompanyShortName=""Japan Airlines""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""144""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H50M"" TotalMiles=""2285"" TotalTripTime=""PT4H50M"" FLSDepartureDateTime=""2013-07-08T14:40:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T22:30:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708BA2494"">
<FlightLegDetails DepartureDateTime=""2013-07-08T14:40:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T22:30:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""2494"" JourneyDuration=""PT4H50M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708BA2494"" FLSUUIDActualFlight=""LAXIAD20130708BA2494[OpBy:American Airlines!AA144]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""BA"" CodeContext=""IATA"" CompanyShortName=""British Airways""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""144""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT6H01M"" TotalMiles=""2465"" TotalTripTime=""PT6H39M"" FLSDepartureDateTime=""2013-07-08T12:55:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T22:34:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708DL2168/2164"">
<FlightLegDetails DepartureDateTime=""2013-07-08T12:55:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T18:32:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""2168"" JourneyDuration=""PT3H37M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 1"" FLSUUID=""LAXMSP20130708DL2168"" FLSUUIDActualFlight=""LAXMSP20130708DL2168[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""5"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""MSP"" FLSLocationName=""Minneapolis"" Terminal=""1""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""2168""></OperatingAirline>
<Equipment AirEquipType=""757""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T19:10:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T22:34:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""2164"" JourneyDuration=""PT2H24M"" SequenceNumber=""2"" FLSMeals=""V"" FLSInflightServices="" "" FLSUUID=""MSPDCA20130708DL2164"" FLSUUIDActualFlight=""MSPDCA20130708DL2164[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""MSP"" FLSLocationName=""Minneapolis"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""2164""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT6H01M"" TotalMiles=""2442"" TotalTripTime=""PT6H49M"" FLSDepartureDateTime=""2013-07-08T12:55:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T22:44:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708DL2168/5776"">
<FlightLegDetails DepartureDateTime=""2013-07-08T12:55:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T18:32:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""2168"" JourneyDuration=""PT3H37M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 1"" FLSUUID=""LAXMSP20130708DL2168"" FLSUUIDActualFlight=""LAXMSP20130708DL2168[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""5"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""MSP"" FLSLocationName=""Minneapolis"" Terminal=""1""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""2168""></OperatingAirline>
<Equipment AirEquipType=""757""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T19:20:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T22:44:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""5776"" JourneyDuration=""PT2H24M"" SequenceNumber=""2"" FLSMeals=""V"" FLSInflightServices="" "" FLSUUID=""MSPIAD20130708DL5776"" FLSUUIDActualFlight=""MSPIAD20130708DL5776[Ownr:COMPASS DBA DELTA CONNECTION!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""MSP"" FLSLocationName=""Minneapolis"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""5776""></OperatingAirline>
<Equipment AirEquipType=""E75""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H53M"" TotalMiles=""2382"" TotalTripTime=""PT6H44M"" FLSDepartureDateTime=""2013-07-08T13:15:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T22:59:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708DL18/5554"">
<FlightLegDetails DepartureDateTime=""2013-07-08T13:15:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T20:39:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""18"" JourneyDuration=""PT4H24M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 1"" FLSUUID=""LAXDTW20130708DL18"" FLSUUIDActualFlight=""LAXDTW20130708DL18[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""5"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DTW"" FLSLocationName=""Detroit"" Terminal=""EM""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""18""></OperatingAirline>
<Equipment AirEquipType=""763""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T21:30:00"" FLSDepartureTimeOffset=""-0400"" ArrivalDateTime=""2013-07-08T22:59:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""5554"" JourneyDuration=""PT1H29M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""DTWDCA20130708DL5554"" FLSUUIDActualFlight=""DTWDCA20130708DL5554[Ownr:EXPRESSJET DBA DELTA CONNECTION!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""DTW"" FLSLocationName=""Detroit"" Terminal=""EM"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""5554""></OperatingAirline>
<Equipment AirEquipType=""CR7""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H55M"" TotalMiles=""2425"" TotalTripTime=""PT6H55M"" FLSDepartureDateTime=""2013-07-08T13:30:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T23:25:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708AA2448/1432"">
<FlightLegDetails DepartureDateTime=""2013-07-08T13:30:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T18:40:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""2448"" JourneyDuration=""PT3H10M"" SequenceNumber=""1"" FLSMeals=""G"" FLSInflightServices="" 9"" FLSUUID=""LAXDFW20130708AA2448"" FLSUUIDActualFlight=""LAXDFW20130708AA2448[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DFW"" FLSLocationName=""Dallas/Fort Worth"" Terminal=""0""></ArrivalAirport>
<MarketingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""2448""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T19:40:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T23:25:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""1432"" JourneyDuration=""PT2H45M"" SequenceNumber=""2"" FLSMeals=""F"" FLSInflightServices="" 9"" FLSUUID=""DFWDCA20130708AA1432"" FLSUUIDActualFlight=""DFWDCA20130708AA1432[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""DFW"" FLSLocationName=""Dallas/Fort Worth"" Terminal=""0"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""1432""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H55M"" TotalMiles=""2425"" TotalTripTime=""PT6H55M"" FLSDepartureDateTime=""2013-07-08T13:30:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T23:25:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708BA4414/4435"">
<FlightLegDetails DepartureDateTime=""2013-07-08T13:30:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T18:40:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""4414"" JourneyDuration=""PT3H10M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXDFW20130708BA4414"" FLSUUIDActualFlight=""LAXDFW20130708BA4414[OpBy:American Airlines!AA2448]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DFW"" FLSLocationName=""Dallas/Fort Worth"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""BA"" CodeContext=""IATA"" CompanyShortName=""British Airways""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""2448""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T19:40:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T23:25:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""4435"" JourneyDuration=""PT2H45M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""DFWDCA20130708BA4435"" FLSUUIDActualFlight=""DFWDCA20130708BA4435[OpBy:American Airlines!AA1432]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""DFW"" FLSLocationName=""Dallas/Fort Worth"" Terminal=""B"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""BA"" CodeContext=""IATA"" CompanyShortName=""British Airways""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""1432""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H35M"" TotalMiles=""2326"" TotalTripTime=""PT6H25M"" FLSDepartureDateTime=""2013-07-08T14:25:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T23:50:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708WN435/318"">
<FlightLegDetails DepartureDateTime=""2013-07-08T14:25:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T20:20:00"" FLSArrivalTimeOffset=""-0500"" FlightNumber=""435"" JourneyDuration=""PT3H55M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""LAXMDW20130708WN435"" FLSUUIDActualFlight=""LAXMDW20130708WN435[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""MDW"" FLSLocationName=""Chicago Midway"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""WN"" CodeContext=""IATA"" CompanyShortName=""Southwest Airlines""></MarketingAirline>
<OperatingAirline Code=""WN"" CodeContext=""IATA"" CompanyShortName=""Southwest Airlines"" FlightNumber=""435""></OperatingAirline>
<Equipment AirEquipType=""73H""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T21:10:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-08T23:50:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""318"" JourneyDuration=""PT1H40M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""MDWIAD20130708WN318"" FLSUUIDActualFlight=""MDWIAD20130708WN318[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""MDW"" FLSLocationName=""Chicago Midway"" Terminal="" "" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""WN"" CodeContext=""IATA"" CompanyShortName=""Southwest Airlines""></MarketingAirline>
<OperatingAirline Code=""WN"" CodeContext=""IATA"" CompanyShortName=""Southwest Airlines"" FlightNumber=""318""></OperatingAirline>
<Equipment AirEquipType=""73W""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT6H08M"" TotalMiles=""2518"" TotalTripTime=""PT6H56M"" FLSDepartureDateTime=""2013-07-08T13:55:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-08T23:51:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator="""" FLSUUID=""LAXWAS20130708US30/3789"">
<FlightLegDetails DepartureDateTime=""2013-07-08T13:55:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T22:06:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""30"" JourneyDuration=""PT5H11M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXPHL20130708US30"" FLSUUIDActualFlight=""LAXPHL20130708US30[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""1"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""PHL"" FLSLocationName=""Philadelphia"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways"" FlightNumber=""30""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T22:54:00"" FLSDepartureTimeOffset=""-0400"" ArrivalDateTime=""2013-07-08T23:51:00"" FLSArrivalTimeOffset=""-0400"" FlightNumber=""3789"" JourneyDuration=""PT0H57M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""PHLDCA20130708US3789"" FLSUUIDActualFlight=""PHLDCA20130708US3789[Ownr:US AIRWAYS EXPRESS-AIR WISCONSIN!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""PHL"" FLSLocationName=""Philadelphia"" Terminal=""F"" FLSDayIndicator="""" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""C""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways"" FlightNumber=""3789""></OperatingAirline>
<Equipment AirEquipType=""CRJ""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H49M"" TotalMiles=""2285"" TotalTripTime=""PT4H49M"" FLSDepartureDateTime=""2013-07-08T16:55:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T00:44:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708UA324"">
<FlightLegDetails DepartureDateTime=""2013-07-08T16:55:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T00:44:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""324"" JourneyDuration=""PT4H49M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXIAD20130708UA324"" FLSUUIDActualFlight=""LAXIAD20130708UA324[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""324""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H49M"" TotalMiles=""2285"" TotalTripTime=""PT4H49M"" FLSDepartureDateTime=""2013-07-08T16:55:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T00:44:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708US6789"">
<FlightLegDetails DepartureDateTime=""2013-07-08T16:55:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T00:44:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""6789"" JourneyDuration=""PT4H49M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXIAD20130708US6789"" FLSUUIDActualFlight=""LAXIAD20130708US6789[OpBy:United Airlines!UA324]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""324""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H49M"" TotalMiles=""2285"" TotalTripTime=""PT4H49M"" FLSDepartureDateTime=""2013-07-08T16:55:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T00:44:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708NZ9046"">
<FlightLegDetails DepartureDateTime=""2013-07-08T16:55:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T00:44:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""9046"" JourneyDuration=""PT4H49M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708NZ9046"" FLSUUIDActualFlight=""LAXIAD20130708NZ9046[OpBy:United Airlines!UA324]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""NZ"" CodeContext=""IATA"" CompanyShortName=""Air New Zealand""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""324""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H37M"" TotalMiles=""2312"" TotalTripTime=""PT6H50M"" FLSDepartureDateTime=""2013-07-08T15:09:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T00:59:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708UA443/1265"">
<FlightLegDetails DepartureDateTime=""2013-07-08T15:09:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T18:30:00"" FLSArrivalTimeOffset=""-0600"" DateChangeNbr=""+1"" FlightNumber=""443"" JourneyDuration=""PT2H21M"" SequenceNumber=""1"" FLSMeals=""G"" FLSInflightServices="" "" FLSUUID=""LAXDEN20130708UA443"" FLSUUIDActualFlight=""LAXDEN20130708UA443[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DEN"" FLSLocationName=""Denver"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""443""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T19:43:00"" FLSDepartureTimeOffset=""-0600"" ArrivalDateTime=""2013-07-09T00:59:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""1265"" JourneyDuration=""PT3H16M"" SequenceNumber=""2"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""DENIAD20130708UA1265"" FLSUUIDActualFlight=""DENIAD20130708UA1265[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""DEN"" FLSLocationName=""Denver"" Terminal="" "" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1265""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H59M"" TotalMiles=""2285"" TotalTripTime=""PT4H59M"" FLSDepartureDateTime=""2013-07-08T17:46:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T01:45:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708UA1598"">
<FlightLegDetails DepartureDateTime=""2013-07-08T17:46:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T01:45:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""1598"" JourneyDuration=""PT4H59M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXIAD20130708UA1598"" FLSUUIDActualFlight=""LAXIAD20130708UA1598[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1598""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H59M"" TotalMiles=""2285"" TotalTripTime=""PT4H59M"" FLSDepartureDateTime=""2013-07-08T17:46:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T01:45:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708NZ9116"">
<FlightLegDetails DepartureDateTime=""2013-07-08T17:46:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T01:45:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""9116"" JourneyDuration=""PT4H59M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708NZ9116"" FLSUUIDActualFlight=""LAXIAD20130708NZ9116[OpBy:United Airlines!UA1598]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""NZ"" CodeContext=""IATA"" CompanyShortName=""Air New Zealand""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1598""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H59M"" TotalMiles=""2285"" TotalTripTime=""PT4H59M"" FLSDepartureDateTime=""2013-07-08T17:46:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T01:45:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708CA7264"">
<FlightLegDetails DepartureDateTime=""2013-07-08T17:46:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T01:45:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""7264"" JourneyDuration=""PT4H59M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" "" FLSUUID=""LAXIAD20130708CA7264"" FLSUUIDActualFlight=""LAXIAD20130708CA7264[OpBy:United Airlines!UA1598]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""CA"" CodeContext=""IATA"" CompanyShortName=""Air China""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1598""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H50M"" TotalMiles=""2285"" TotalTripTime=""PT4H50M"" FLSDepartureDateTime=""2013-07-08T22:00:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T05:50:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708VX114"">
<FlightLegDetails DepartureDateTime=""2013-07-08T22:00:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T05:50:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""114"" JourneyDuration=""PT4H50M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708VX114"" FLSUUIDActualFlight=""LAXIAD20130708VX114[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""3"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""VX"" CodeContext=""IATA"" CompanyShortName=""Virgin America""></MarketingAirline>
<OperatingAirline Code=""VX"" CodeContext=""IATA"" CompanyShortName=""Virgin America"" FlightNumber=""114""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H50M"" TotalMiles=""2285"" TotalTripTime=""PT4H50M"" FLSDepartureDateTime=""2013-07-08T22:00:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T05:50:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708VA6004"">
<FlightLegDetails DepartureDateTime=""2013-07-08T22:00:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T05:50:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""6004"" JourneyDuration=""PT4H50M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708VA6004"" FLSUUIDActualFlight=""LAXIAD20130708VA6004[OpBy:Virgin America!VX114]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""3"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""VA"" CodeContext=""IATA"" CompanyShortName=""Virgin Australia Intl""></MarketingAirline>
<OperatingAirline Code=""VX"" CodeContext=""IATA"" CompanyShortName=""Virgin America"" FlightNumber=""114""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H50M"" TotalMiles=""2285"" TotalTripTime=""PT4H50M"" FLSDepartureDateTime=""2013-07-08T22:00:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T05:50:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708HA2532"">
<FlightLegDetails DepartureDateTime=""2013-07-08T22:00:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T05:50:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""2532"" JourneyDuration=""PT4H50M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708HA2532"" FLSUUIDActualFlight=""LAXIAD20130708HA2532[OpBy:VIRGIN AMERICA!VX114]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""3"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""HA"" CodeContext=""IATA"" CompanyShortName=""Hawaiian Airlines""></MarketingAirline>
<OperatingAirline Code=""VX"" CodeContext=""IATA"" CompanyShortName=""Virgin America"" FlightNumber=""114""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H38M"" TotalMiles=""2360"" TotalTripTime=""PT6H30M"" FLSDepartureDateTime=""2013-07-08T20:31:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T06:01:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708US6976/6562"">
<FlightLegDetails DepartureDateTime=""2013-07-08T20:31:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T21:25:00"" FLSArrivalTimeOffset=""-0700"" DateChangeNbr=""+1"" FlightNumber=""6976"" JourneyDuration=""PT0H54M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""LAXSAN20130708US6976"" FLSUUIDActualFlight=""LAXSAN20130708US6976[OpBy:SKYWEST DBA UNITED EXPRESS!UA6342]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""8"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""SAN"" FLSLocationName=""San Diego"" Terminal=""R""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""6342""></OperatingAirline>
<Equipment AirEquipType=""EM2""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T22:17:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T06:01:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""6562"" JourneyDuration=""PT4H44M"" SequenceNumber=""2"" FLSMeals=""G"" FLSInflightServices="" "" FLSUUID=""SANIAD20130708US6562"" FLSUUIDActualFlight=""SANIAD20130708US6562[OpBy:United Airlines!UA238]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""SAN"" FLSLocationName=""San Diego"" Terminal=""1"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""238""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H38M"" TotalMiles=""2360"" TotalTripTime=""PT6H30M"" FLSDepartureDateTime=""2013-07-08T20:31:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T06:01:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708UA6342/238"">
<FlightLegDetails DepartureDateTime=""2013-07-08T20:31:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-08T21:25:00"" FLSArrivalTimeOffset=""-0700"" DateChangeNbr=""+1"" FlightNumber=""6342"" JourneyDuration=""PT0H54M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""LAXSAN20130708UA6342"" FLSUUIDActualFlight=""LAXSAN20130708UA6342[Ownr:SKYWEST DBA UNITED EXPRESS!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""8"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""SAN"" FLSLocationName=""San Diego"" Terminal=""R""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""6342""></OperatingAirline>
<Equipment AirEquipType=""EM2""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-08T22:17:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T06:01:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""238"" JourneyDuration=""PT4H44M"" SequenceNumber=""2"" FLSMeals=""G"" FLSInflightServices="" "" FLSUUID=""SANIAD20130708UA238"" FLSUUIDActualFlight=""SANIAD20130708UA238[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""SAN"" FLSLocationName=""San Diego"" Terminal=""1"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""238""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H50M"" TotalMiles=""2285"" TotalTripTime=""PT4H50M"" FLSDepartureDateTime=""2013-07-08T22:35:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T06:25:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708AA74"">
<FlightLegDetails DepartureDateTime=""2013-07-08T22:35:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T06:25:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""74"" JourneyDuration=""PT4H50M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 1/ 9"" FLSUUID=""LAXIAD20130708AA74"" FLSUUIDActualFlight=""LAXIAD20130708AA74[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""74""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H50M"" TotalMiles=""2285"" TotalTripTime=""PT4H50M"" FLSDepartureDateTime=""2013-07-08T22:35:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T06:25:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708QF3083"">
<FlightLegDetails DepartureDateTime=""2013-07-08T22:35:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T06:25:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""3083"" JourneyDuration=""PT4H50M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708QF3083"" FLSUUIDActualFlight=""LAXIAD20130708QF3083[OpBy:American Airlines!AA74]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""QF"" CodeContext=""IATA"" CompanyShortName=""Qantas Airways""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""74""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H50M"" TotalMiles=""2285"" TotalTripTime=""PT4H50M"" FLSDepartureDateTime=""2013-07-08T22:35:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T06:25:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708FJ5042"">
<FlightLegDetails DepartureDateTime=""2013-07-08T22:35:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T06:25:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""5042"" JourneyDuration=""PT4H50M"" SequenceNumber=""1"" FLSMeals=""O"" FLSInflightServices="" 1/ 9"" FLSUUID=""LAXIAD20130708FJ5042"" FLSUUIDActualFlight=""LAXIAD20130708FJ5042[OpBy:American Airlines!AA74]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""B"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""FJ"" CodeContext=""IATA"" CompanyShortName=""Air Pacific""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""74""></OperatingAirline>
<Equipment AirEquipType=""739""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H50M"" TotalMiles=""2285"" TotalTripTime=""PT4H50M"" FLSDepartureDateTime=""2013-07-08T22:35:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T06:25:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708BA2488"">
<FlightLegDetails DepartureDateTime=""2013-07-08T22:35:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T06:25:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""2488"" JourneyDuration=""PT4H50M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708BA2488"" FLSUUIDActualFlight=""LAXIAD20130708BA2488[OpBy:American Airlines!AA74]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""BA"" CodeContext=""IATA"" CompanyShortName=""British Airways""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""74""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H54M"" TotalMiles=""2285"" TotalTripTime=""PT4H54M"" FLSDepartureDateTime=""2013-07-08T22:39:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T06:33:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708UA1038"">
<FlightLegDetails DepartureDateTime=""2013-07-08T22:39:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T06:33:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""1038"" JourneyDuration=""PT4H54M"" SequenceNumber=""1"" FLSMeals=""G"" FLSInflightServices="" "" FLSUUID=""LAXIAD20130708UA1038"" FLSUUIDActualFlight=""LAXIAD20130708UA1038[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1038""></OperatingAirline>
<Equipment AirEquipType=""753""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H54M"" TotalMiles=""2285"" TotalTripTime=""PT4H54M"" FLSDepartureDateTime=""2013-07-08T22:39:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T06:33:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708NZ9118"">
<FlightLegDetails DepartureDateTime=""2013-07-08T22:39:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T06:33:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""9118"" JourneyDuration=""PT4H54M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708NZ9118"" FLSUUIDActualFlight=""LAXIAD20130708NZ9118[OpBy:United Airlines!UA1038]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""NZ"" CodeContext=""IATA"" CompanyShortName=""Air New Zealand""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1038""></OperatingAirline>
<Equipment AirEquipType=""753""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT4H54M"" TotalMiles=""2285"" TotalTripTime=""PT4H54M"" FLSDepartureDateTime=""2013-07-08T22:39:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T06:33:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708CA7262"">
<FlightLegDetails DepartureDateTime=""2013-07-08T22:39:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T06:33:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""7262"" JourneyDuration=""PT4H54M"" SequenceNumber=""1"" FLSMeals=""G"" FLSInflightServices="" "" FLSUUID=""LAXIAD20130708CA7262"" FLSUUIDActualFlight=""LAXIAD20130708CA7262[OpBy:United Airlines!UA1038]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""CA"" CodeContext=""IATA"" CompanyShortName=""Air China""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""1038""></OperatingAirline>
<Equipment AirEquipType=""753""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H00M"" TotalMiles=""2285"" TotalTripTime=""PT5H00M"" FLSDepartureDateTime=""2013-07-08T23:15:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T07:15:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708UA772"">
<FlightLegDetails DepartureDateTime=""2013-07-08T23:15:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T07:15:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""772"" JourneyDuration=""PT5H00M"" SequenceNumber=""1"" FLSMeals=""G"" FLSInflightServices="" "" FLSUUID=""LAXIAD20130708UA772"" FLSUUIDActualFlight=""LAXIAD20130708UA772[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""772""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H00M"" TotalMiles=""2285"" TotalTripTime=""PT5H00M"" FLSDepartureDateTime=""2013-07-08T23:15:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T07:15:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708US6506"">
<FlightLegDetails DepartureDateTime=""2013-07-08T23:15:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T07:15:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""6506"" JourneyDuration=""PT5H00M"" SequenceNumber=""1"" FLSMeals=""G"" FLSInflightServices="" "" FLSUUID=""LAXIAD20130708US6506"" FLSUUIDActualFlight=""LAXIAD20130708US6506[OpBy:United Airlines!UA772]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""772""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H00M"" TotalMiles=""2285"" TotalTripTime=""PT5H00M"" FLSDepartureDateTime=""2013-07-08T23:15:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T07:15:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""NonStop"" FLSFlightLegs=""1"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708NZ9102"">
<FlightLegDetails DepartureDateTime=""2013-07-08T23:15:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T07:15:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""9102"" JourneyDuration=""PT5H00M"" SequenceNumber=""1"" FLSMeals="""" FLSInflightServices="" 9"" FLSUUID=""LAXIAD20130708NZ9102"" FLSUUIDActualFlight=""LAXIAD20130708NZ9102[OpBy:United Airlines!UA772]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""NZ"" CodeContext=""IATA"" CompanyShortName=""Air New Zealand""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""772""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H50M"" TotalMiles=""2356"" TotalTripTime=""PT6H40M"" FLSDepartureDateTime=""2013-07-08T22:50:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T08:30:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708AA1360/4436"">
<FlightLegDetails DepartureDateTime=""2013-07-08T22:50:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T05:00:00"" FLSArrivalTimeOffset=""-0500"" DateChangeNbr=""+1"" FlightNumber=""1360"" JourneyDuration=""PT4H10M"" SequenceNumber=""1"" FLSMeals=""F"" FLSInflightServices="" 1/ 9"" FLSUUID=""LAXBNA20130708AA1360"" FLSUUIDActualFlight=""LAXBNA20130708AA1360[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""4"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""BNA"" FLSLocationName=""Nashville"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""1360""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-09T05:50:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-09T08:30:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""4436"" JourneyDuration=""PT1H40M"" SequenceNumber=""2"" FLSMeals=""F"" FLSInflightServices="" 9"" FLSUUID=""BNADCA20130708AA4436"" FLSUUIDActualFlight=""BNADCA20130708AA4436[Ownr:AMERICAN EAGLE AIRLINES!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""BNA"" FLSLocationName=""Nashville"" Terminal="" "" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""DCA"" FLSLocationName=""Washington Reagan"" Terminal=""B""></ArrivalAirport>
<MarketingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines""></MarketingAirline>
<OperatingAirline Code=""AA"" CodeContext=""IATA"" CompanyShortName=""American Airlines"" FlightNumber=""4436""></OperatingAirline>
<Equipment AirEquipType=""ERD""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H42M"" TotalMiles=""2331"" TotalTripTime=""PT6H25M"" FLSDepartureDateTime=""2013-07-08T23:20:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T08:45:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708UA564/575"">
<FlightLegDetails DepartureDateTime=""2013-07-08T23:20:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T05:17:00"" FLSArrivalTimeOffset=""-0500"" DateChangeNbr=""+1"" FlightNumber=""564"" JourneyDuration=""PT3H57M"" SequenceNumber=""1"" FLSMeals=""G"" FLSInflightServices="" "" FLSUUID=""LAXORD20130708UA564"" FLSUUIDActualFlight=""LAXORD20130708UA564[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""1""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""564""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-09T06:00:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-09T08:45:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""575"" JourneyDuration=""PT1H45M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""ORDIAD20130708UA575"" FLSUUIDActualFlight=""ORDIAD20130708UA575[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""1"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""575""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H42M"" TotalMiles=""2331"" TotalTripTime=""PT6H25M"" FLSDepartureDateTime=""2013-07-08T23:20:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T08:45:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708US6651/6538"">
<FlightLegDetails DepartureDateTime=""2013-07-08T23:20:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T05:17:00"" FLSArrivalTimeOffset=""-0500"" DateChangeNbr=""+1"" FlightNumber=""6651"" JourneyDuration=""PT3H57M"" SequenceNumber=""1"" FLSMeals=""G"" FLSInflightServices="" "" FLSUUID=""LAXORD20130708US6651"" FLSUUIDActualFlight=""LAXORD20130708US6651[OpBy:United Airlines!UA564]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""1""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""564""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
<FlightLegDetails DepartureDateTime=""2013-07-09T06:00:00"" FLSDepartureTimeOffset=""-0500"" ArrivalDateTime=""2013-07-09T08:45:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""6538"" JourneyDuration=""PT1H45M"" SequenceNumber=""2"" FLSMeals="""" FLSInflightServices="" "" FLSUUID=""ORDIAD20130708US6538"" FLSUUIDActualFlight=""ORDIAD20130708US6538[OpBy:United Airlines!UA575]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""1"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""IAD"" FLSLocationName=""Washington Dulles"" Terminal="" ""></ArrivalAirport>
<MarketingAirline Code=""US"" CodeContext=""IATA"" CompanyShortName=""US Airways""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""575""></OperatingAirline>
<Equipment AirEquipType=""752""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H46M"" TotalMiles=""2309"" TotalTripTime=""PT6H50M"" FLSDepartureDateTime=""2013-07-08T22:55:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T08:45:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708DL1936/5453"">
<FlightLegDetails DepartureDateTime=""2013-07-08T22:55:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T06:11:00"" FLSArrivalTimeOffset=""-0400"" DateChangeNbr=""+1"" FlightNumber=""1936"" JourneyDuration=""PT4H16M"" SequenceNumber=""1"" FLSMeals=""V"" FLSInflightServices="" 1"" FLSUUID=""LAXCVG20130708DL1936"" FLSUUIDActualFlight=""LAXCVG20130708DL1936[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""5"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""CVG"" FLSLocationName=""Cincinnati"" Terminal=""3""></ArrivalAirport>
<MarketingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines""></MarketingAirline>
<OperatingAirline Code=""DL"" CodeContext=""IATA"" CompanyShortName=""Delta Air Lines"" FlightNumber=""1936""></OperatingAirline>
<Equipment AirEquipType=""738""></Equipment>
</FlightLegDetails>
</FlightDetails>
<FlightDetails TotalFlightTime=""PT5H44M"" TotalMiles=""2354"" TotalTripTime=""PT6H27M"" FLSDepartureDateTime=""2013-07-08T23:20:00"" FLSDepartureTimeOffset=""-0700"" FLSDepartureCode=""LAX"" FLSDepartureName=""Los Angeles Metro"" FLSArrivalDateTime=""2013-07-09T08:47:00"" FLSArrivalTimeOffset=""-0400"" FLSArrivalCode=""WAS"" FLSArrivalName=""Washington (ALL)"" FLSFlightType=""Connect"" FLSFlightLegs=""2"" FLSFlightDays=""1......"" FLSDayIndicator=""+1"" FLSUUID=""LAXWAS20130708UA564/600"">
<FlightLegDetails DepartureDateTime=""2013-07-08T23:20:00"" FLSDepartureTimeOffset=""-0700"" ArrivalDateTime=""2013-07-09T05:17:00"" FLSArrivalTimeOffset=""-0500"" DateChangeNbr=""+1"" FlightNumber=""564"" JourneyDuration=""PT3H57M"" SequenceNumber=""1"" FLSMeals=""G"" FLSInflightServices="" "" FLSUUID=""LAXORD20130708UA564"" FLSUUIDActualFlight=""LAXORD20130708UA564[!]"">
<DepartureAirport CodeContext=""IATA"" LocationCode=""LAX"" FLSLocationName=""Los Angeles"" Terminal=""7"" FLSDayIndicator=""+1"" FLSDOTDisclosure=""""></DepartureAirport>
<ArrivalAirport CodeContext=""IATA"" LocationCode=""ORD"" FLSLocationName=""Chicago O'Hare"" Terminal=""1""></ArrivalAirport>
<MarketingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines""></MarketingAirline>
<OperatingAirline Code=""UA"" CodeContext=""IATA"" CompanyShortName=""United Airlines"" FlightNumber=""564""></OperatingAirline>
<Equipment AirEquipType=""320""></Equipment>
</FlightLegDetails>
</FlightDetails>
</OTA_AirDetailsRS>";
    }
}