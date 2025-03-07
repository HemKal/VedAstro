﻿

//▄▀█   █░░ █ █▀▀   █ █▀   ░░█ █░█ █▀ ▀█▀   ▄▀█   █▀▀ █▀█ █▀▀ ▄▀█ ▀█▀   █▀ ▀█▀ █▀█ █▀█ █▄█   ▀█▀ █░█ ▄▀█ ▀█▀
//█▀█   █▄▄ █ ██▄   █ ▄█   █▄█ █▄█ ▄█ ░█░   █▀█   █▄█ █▀▄ ██▄ █▀█ ░█░   ▄█ ░█░ █▄█ █▀▄ ░█░   ░█░ █▀█ █▀█ ░█░

//█▀ █▀█ █▀▄▀█ █▀▀ █▀█ █▄░█ █▀▀   █▀█ █░█ █ █▄░█ █▀▀ █▀▄   █░█░█ █ ▀█▀ █░█   ▀█▀ █░█ █▀▀   ▀█▀ █▀█ █░█ ▀█▀ █░█
//▄█ █▄█ █░▀░█ ██▄ █▄█ █░▀█ ██▄   █▀▄ █▄█ █ █░▀█ ██▄ █▄▀   ▀▄▀▄▀ █ ░█░ █▀█   ░█░ █▀█ ██▄   ░█░ █▀▄ █▄█ ░█░ █▀█
//Barnabus Stinson



using System.Collections.Generic;
using System.Linq;

namespace VedAstro.Library
{
    /// <summary>
    /// A collection of methods used to calculate if an event is occuring
    /// Note:
    /// - Attributes are used to link a particular method to the event data stored in database
    /// - Split across file because VS IDE started to lag with autocomplete (too much code at once)
    /// </summary>
    public static partial class EventCalculatorMethods
    {
        [EventCalculator(EventName.Empty)]
        public static CalculatorResult Empty(Time time, Person person) => CalculatorResult.NotOccuring();

        #region PERSONAL
        //[EventCalculator(EventName.GoodTarabala)] TODO Can be removed and fucntion moved to astronomical
        public static CalculatorResult IsGoodTarabalaOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            switch (tarabala.GetName())
            {   //return true for good tarabala names
                case TarabalaName.Sampat:
                    return CalculatorResult.IsOccuring();
                case TarabalaName.Kshema:
                    return CalculatorResult.IsOccuring();
                case TarabalaName.Sadhana:
                    return CalculatorResult.IsOccuring();
                case TarabalaName.Mitra:
                    return CalculatorResult.IsOccuring();
                case TarabalaName.ParamaMitra:
                    return CalculatorResult.IsOccuring();
                //return false if no good tarabala names matched
                default:
                    return CalculatorResult.NotOccuring();
            }
        }

        //[EventCalculator(EventName.BadTarabala)] TODO Can be removed and fucntion moved to astronomical
        public static CalculatorResult IsBadTarabalaOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            switch (tarabala.GetName())
            {   //return true if tarabala is false
                case TarabalaName.Janma:
                    return CalculatorResult.IsOccuring();
                case TarabalaName.Vipat:
                    return CalculatorResult.IsOccuring();
                case TarabalaName.Pratyak:
                    return CalculatorResult.IsOccuring();
                case TarabalaName.Naidhana:
                    return CalculatorResult.IsOccuring();
                //return false if no bad tarabala names matched
                default:
                    return CalculatorResult.NotOccuring();
            }
        }

        [EventCalculator(EventName.TarabalaJanmaStrong)]
        public static CalculatorResult IsTarabalaJanmaStrongOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);
            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Janma && tarabala.GetCycle() == 1;

            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.TarabalaSampatStrong)]
        public static CalculatorResult IsTarabalaSampatStrongOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Sampat && tarabala.GetCycle() == 1;

            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaVipatStrong)]
        public static CalculatorResult IsTarabalaVipatStrongOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Vipat && tarabala.GetCycle() == 1;

            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaKshemaStrong)]
        public static CalculatorResult IsTarabalaKshemaStrongOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Kshema && tarabala.GetCycle() == 1;

            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaPratyakStrong)]
        public static CalculatorResult IsTarabalaPratyakStrongOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Pratyak && tarabala.GetCycle() == 1;

            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.TarabalaSadhanaStrong)]
        public static CalculatorResult IsTarabalaSadhanaStrongOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Sadhana && tarabala.GetCycle() == 1;

            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaNaidhanaStrong)]
        public static CalculatorResult IsTarabalaNaidhanaStrongOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Naidhana && tarabala.GetCycle() == 1;

            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaMitraStrong)]
        public static CalculatorResult IsTarabalaMitraStrongOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Mitra && tarabala.GetCycle() == 1;

            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaParamaMitraStrong)]
        public static CalculatorResult IsTarabalaParamaMitraStrongOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.ParamaMitra && tarabala.GetCycle() == 1;
            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaJanmaMiddling)]
        public static CalculatorResult IsTarabalaJanmaMiddlingOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Janma && tarabala.GetCycle() == 2;
            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaSampatMiddling)]
        public static CalculatorResult IsTarabalaSampatMiddlingOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Sampat && tarabala.GetCycle() == 2;
            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaVipatMiddling)]
        public static CalculatorResult IsTarabalaVipatMiddlingOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Vipat && tarabala.GetCycle() == 2;
            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaKshemaMiddling)]
        public static CalculatorResult IsTarabalaKshemaMiddlingOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Kshema && tarabala.GetCycle() == 2;
            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaPratyakMiddling)]
        public static CalculatorResult IsTarabalaPratyakMiddlingOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Pratyak && tarabala.GetCycle() == 2;
            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaSadhanaMiddling)]
        public static CalculatorResult IsTarabalaSadhanaMiddlingOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Sadhana && tarabala.GetCycle() == 2;
            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaNaidhanaMiddling)]
        public static CalculatorResult IsTarabalaNaidhanaMiddlingOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Naidhana && tarabala.GetCycle() == 2;
            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaMitraMiddling)]
        public static CalculatorResult IsTarabalaMitraMiddlingOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Mitra && tarabala.GetCycle() == 2;
            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaParamaMitraMiddling)]
        public static CalculatorResult IsTarabalaParamaMitraMiddlingOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.ParamaMitra && tarabala.GetCycle() == 2;
            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaJanmaWeak)]
        public static CalculatorResult IsTarabalaJanmaWeakOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Janma && tarabala.GetCycle() == 3;
            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaSampatWeak)]
        public static CalculatorResult IsTarabalaSampatWeakOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Sampat && tarabala.GetCycle() == 3;
            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaVipatWeak)]
        public static CalculatorResult IsTarabalaVipatWeakOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Vipat && tarabala.GetCycle() == 3;
            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaKshemaWeak)]
        public static CalculatorResult IsTarabalaKshemaWeakOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Kshema && tarabala.GetCycle() == 3;
            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.TarabalaPratyakWeak)]
        public static CalculatorResult IsTarabalaPratyakWeakOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Pratyak && tarabala.GetCycle() == 3;
            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.TarabalaSadhanaWeak)]
        public static CalculatorResult IsTarabalaSadhanaWeakOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Sadhana && tarabala.GetCycle() == 3;
            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.TarabalaNaidhanaWeak)]
        public static CalculatorResult IsTarabalaNaidhanaWeakOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Naidhana && tarabala.GetCycle() == 3;
            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.TarabalaMitraWeak)]
        public static CalculatorResult IsTarabalaMitraWeakOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.Mitra && tarabala.GetCycle() == 3;
            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.TarabalaParamaMitraWeak)]
        public static CalculatorResult IsTarabalaParamaMitraWeakOccuring(Time time, Person person)
        {
            //get tarabala for current time
            var tarabala = AstronomicalCalculator.GetTarabala(time, person);

            //event occuring based on tarabala name & cycle
            var occuring = tarabala.GetName() == TarabalaName.ParamaMitra && tarabala.GetCycle() == 3;
            return new() { Occuring = occuring };
        }



        [EventCalculator(EventName.GoodChandrabala)]
        public static CalculatorResult IsGoodChandrabalaOccuring(Time time, Person person)
        {
            //if bad chandrabala is occuring
            if (IsBadChandrabalaOccuring(time, person).Occuring)
            {
                //return false
                return CalculatorResult.NotOccuring();
            }
            else
            {   //if bad chandrabala is not occuring good chandrabala is occuring
                return CalculatorResult.IsOccuring();
            }
        }

        [EventCalculator(EventName.BadChandrabala)]
        public static CalculatorResult IsBadChandrabalaOccuring(Time time, Person person)
        {
            //get chandrabala number for time
            var chandrabalaNumber = AstronomicalCalculator.GetChandrabala(time, person);

            switch (chandrabalaNumber)
            {
                case 6:
                    return CalculatorResult.IsOccuring();
                case 8:
                    {
                        //Chandrashtama shows no evil when the Moon is waxing and
                        // occupies a benefic sign and a benefic Navamsa, or when there is
                        // Tarabala. The sting is lost when the Moon and the 8th lord are friends.

                        //if any of the 3 exception conditions are met, bad chandrabala is nulified
                        if (condition1() || condition2() || condition3()) { return CalculatorResult.NotOccuring(); }

                        return CalculatorResult.IsOccuring();
                    }

                case 12:
                    return CalculatorResult.IsOccuring();
                default:
                    return CalculatorResult.NotOccuring();
            }

            //condition 1 : Moon is waxing AND occupies a benefic sign AND a benefic Navamsa
            bool condition1()
            {
                //1. Moon is waxing
                var moonPhase = AstronomicalCalculator.GetLunarDay(time).GetMoonPhase();

                //check if phase is correct 
                var rightPhase = moonPhase == MoonPhase.BrightHalf;

                //if not correct phase, end here as not occuring
                if (rightPhase == false) { return false; }


                //2. Moon occupies a benefic sign
                var moonSign = AstronomicalCalculator.GetPlanetRasiSign(PlanetName.Moon, time);
                var relationship = AstronomicalCalculator.GetPlanetRelationshipWithSign(PlanetName.Moon, moonSign.GetSignName(), time);

                //check if sign is benefic 
                var isBenefic = relationship == PlanetToSignRelationship.OwnVarga || //Swavarga - own varga
                                relationship == PlanetToSignRelationship.FriendVarga || //Mitravarga - friendly varga
                                relationship == PlanetToSignRelationship.BestFriendVarga; //Adhi Mitravarga - Intimate friend varga

                //if not benefic, end here as not occuring
                if (isBenefic == false) { return false; }


                //3. Moon occupies a benefic Navamsa sign
                var moonNavamsaSign = AstronomicalCalculator.GetPlanetNavamsaSign(PlanetName.Moon, time);
                var navamsaRelationship = AstronomicalCalculator.GetPlanetRelationshipWithSign(PlanetName.Moon, moonNavamsaSign, time);

                //check if sign is benefic 
                var isBeneficNavamsa = navamsaRelationship == PlanetToSignRelationship.OwnVarga || //Swavarga - own varga
                                navamsaRelationship == PlanetToSignRelationship.FriendVarga || //Mitravarga - friendly varga
                                navamsaRelationship == PlanetToSignRelationship.BestFriendVarga; //Adhi Mitravarga - Intimate friend varga

                //if not benefic, end here as not occuring
                if (isBeneficNavamsa == false) { return false; }


                //if control reaches here then condition is met
                return true;
            }

            //condition 2 : there is good Tarabala
            bool condition2()
            {
                return IsGoodTarabalaOccuring(time, person).Occuring;
            }

            //condition 3 : when the Moon and the 8th lord are friends
            bool condition3()
            {
                //get lord of 8th house
                var lord8th = AstronomicalCalculator.GetLordOfHouse(HouseName.House8, time);

                //get relationship between moon and 8th lord
                var relationship =
                    AstronomicalCalculator.GetPlanetCombinedRelationshipWithPlanet(PlanetName.Moon, lord8th, time);

                var isFriends = relationship == PlanetToPlanetRelationship.BestFriend ||
                                relationship == PlanetToPlanetRelationship.Friend;

                return isFriends;
            }

        }

        [EventCalculator(EventName.GoodPanchaka)]
        public static CalculatorResult IsGoodPanchakaOccuring(Time time, Person person)
        {
            //get occuring panchaka
            var panchakaName = AstronomicalCalculator.GetPanchaka(time);

            //if panchaka is good (subha)
            if (panchakaName == PanchakaName.Shubha)
            {
                //event is occuring
                return CalculatorResult.IsOccuring();
            }
            else
            {
                return CalculatorResult.NotOccuring();
            }
        }

        [EventCalculator(EventName.BadPanchaka)]
        public static CalculatorResult IsBadPanchakaOccuring(Time time, Person person)
        {
            //check if good panchaka occuring 
            var goodPanchakaOcurring = IsGoodPanchakaOccuring(time, person).Occuring;

            //if good panchaka is occuring
            if (goodPanchakaOcurring)
            {
                //bad panchaka is not occuring
                return CalculatorResult.NotOccuring();
            }
            else
            {
                //else bad panchaka is occuring
                return CalculatorResult.IsOccuring();
            }
        }


        //MARKED FOR DELETION BECAUSE NEW VIEW DOESN NEED IT, CREATED FOR GOOGLE CALENDAR

        //[EventCalculator(EventName.BadTaraChandraPanchaka)]
        //public static CalculatorResult IsBadTaraChandraPanchakaOccuring(Time time, Person person)
        //{
        //    //bad tarabala
        //    var badTarabala = IsBadTarabalaOccuring(time, person).Occuring;

        //    //bad chandrabala
        //    var badChandrabala = IsBadChandrabalaOccuring(time, person).Occuring;

        //    //bad panchaka
        //    var badPanchaka = IsBadPanchakaOccuring(time, person).Occuring;


        //    if (badTarabala && badChandrabala && badPanchaka)
        //    {
        //        return CalculatorResult.IsOccuring();
        //    }
        //    else
        //    {
        //        return CalculatorResult.NotOccuring();
        //    }

        //}

        //[EventCalculator(EventName.GoodTaraChandraPanchaka)]
        //public static CalculatorResult IsGoodTaraChandraPanchakaOccuring(Time time, Person person)
        //{
        //    //good tarabala
        //    var goodTarabala = IsGoodTarabalaOccuring(time, person).Occuring;

        //    //good chandrabala
        //    var goodChandrabala = IsGoodChandrabalaOccuring(time, person).Occuring;

        //    //good panchaka
        //    var goodPanchaka = IsGoodPanchakaOccuring(time, person).Occuring;


        //    if (goodTarabala && goodChandrabala && goodPanchaka)
        //    {
        //        return CalculatorResult.IsOccuring();
        //    }
        //    else
        //    {
        //        return CalculatorResult.NotOccuring();
        //    }

        //}

        //[EventCalculator(EventName.GoodTaraChandra)]
        //public static CalculatorResult IsGoodTaraChandraOccuring(Time time, Person person)
        //{
        //    //good tarabala
        //    var goodTarabala = IsGoodTarabalaOccuring(time, person).Occuring;

        //    //good chandrabala
        //    var goodChandrabala = IsGoodChandrabalaOccuring(time, person).Occuring;


        //    if (goodTarabala && goodChandrabala)
        //    {
        //        return CalculatorResult.IsOccuring();
        //    }
        //    else
        //    {
        //        return CalculatorResult.NotOccuring();
        //    }

        //}

        //[EventCalculator(EventName.BadTaraChandra)]
        //public static CalculatorResult IsBadTaraChandraOccuring(Time time, Person person)
        //{
        //    //bad tarabala
        //    var badTarabala = IsBadTarabalaOccuring(time, person).Occuring;

        //    //bad chandrabala
        //    var badChandrabala = IsBadChandrabalaOccuring(time, person).Occuring;


        //    if (badTarabala && badChandrabala)
        //    {
        //        return CalculatorResult.IsOccuring();
        //    }
        //    else
        //    {
        //        return CalculatorResult.NotOccuring();
        //    }

        //}

        [EventCalculator(EventName.JanmaNakshatraRulling)]
        public static CalculatorResult IsJanmaNakshatraRullingOccuring(Time time, Person person)
        {
            //A day ruled by one's Janma Nakshatra is ordinarily held to be
            // unfavourable for an election. But in regard to nuptials, sacrifices, first
            // feeding, agriculture, upanayanam, coronation, buying lands, learning
            // the alphabet, Janma Nakshatra is favourable without exception. But it is
            // inauspicious for war, sexual union, shaving, taking medical treatment,
            // travel and marriage. For a woman, Janma Nakshatra would be quite
            // favourable for marriage.

            //get birth rulling costellation 
            var birthRulingConstellation = AstronomicalCalculator.GetMoonConstellation(person.BirthTime);

            //get current rulling constellation
            var currentRulingConstellation = AstronomicalCalculator.GetMoonConstellation(time);

            //check only if constellation "name" is match (not checking quater), if match event occuring
            var occuring = birthRulingConstellation.GetConstellationName() == currentRulingConstellation.GetConstellationName();
            return new() { Occuring = occuring };

        }


        #endregion

        #region MEDICAL

        [EventCalculator(EventName.UgraYoga)]
        public static CalculatorResult IsUgraYogaOccuring(Time time, Person person)
        {
            //Any treatment commenced under Ugra yogas are supposed to prove
            // successful. Ugra yogas arise when the 3rd (or 9th), 4th, 5th, 6th, 7th,
            // 9th, 10th, 12th (or 3rd) and 13th lunar days coincide respectively with
            // Rohini, Uttara, Sravana, Mrigasira. Revats, Krittika, Pushva, Anuradha.
            // Krittika (or Makha).

            //get lunar day
            var lunarDayNumber = AstronomicalCalculator.GetLunarDay(time).GetLunarDayNumber();
            //get ruling constellation
            var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();


            if (lunarDayNumber == 3 || lunarDayNumber == 9
                || lunarDayNumber == 4 || lunarDayNumber == 5
                || lunarDayNumber == 6 || lunarDayNumber == 7
                || lunarDayNumber == 10 || lunarDayNumber == 12
                || lunarDayNumber == 13)
            {
                //check ruling constellation name
                if (rulingConstellationName == ConstellationName.Rohini ||
                    rulingConstellationName == ConstellationName.Uttara ||
                    rulingConstellationName == ConstellationName.Sravana ||
                    rulingConstellationName == ConstellationName.Mrigasira ||
                    rulingConstellationName == ConstellationName.Revathi ||
                    rulingConstellationName == ConstellationName.Krithika ||
                    rulingConstellationName == ConstellationName.Pushyami ||
                    rulingConstellationName == ConstellationName.Anuradha ||
                    rulingConstellationName == ConstellationName.Makha)
                {
                    return CalculatorResult.IsOccuring();
                }

            }


            //if none of the conditions above are met return false
            return CalculatorResult.NotOccuring();
        }

        [EventCalculator(EventName.GoodTakingInjections)]
        public static CalculatorResult IsGoodTakingInjectionsOccuring(Time time, Person person)
        {
            //Injections may be taken on Saturday or Monday.
            // Aries, Taurus. Cancer and Virgo are auspicious. The 8th house must be
            // unoccupied. See that Mercury'is free from affliction; as otherwise the
            // pain wilt be severe and nervous weakness may set in.

            //get current weekday
            var weekday = AstronomicalCalculator.GetDayOfWeek(time);

            //1. may be taken on Saturday or Monday.
            //right weekdays to look for
            var rightWeekday = weekday == DayOfWeek.Saturday || weekday == DayOfWeek.Monday;

            //if not correct weekdays, end here as not occuring
            if (rightWeekday == false) { return CalculatorResult.NotOccuring(); }


            //2. Aries, Taurus. Cancer and Virgo are auspicious
            //get rising sign
            var risingSign = AstronomicalCalculator.GetHouseSignName(1, time);

            //check rising sign
            var rightSign = risingSign == ZodiacName.Aries
                            || risingSign == ZodiacName.Taurus
                            || risingSign == ZodiacName.Cancer
                            || risingSign == ZodiacName.Virgo;

            //if not correct sign, end here as not occuring
            if (rightSign == false) { return CalculatorResult.NotOccuring(); }


            //3. The 8th house must be unoccupied
            var planets8thHouse = AstronomicalCalculator.GetPlanetsInHouse(8, time);

            //if got planets in 8th house, event not occuring
            if (planets8thHouse.Any()) { return CalculatorResult.NotOccuring(); }


            //4. Mercury is free from affliction
            var mercuryIsAfflicted = AstronomicalCalculator.IsMercuryAfflicted(time);

            //if afflicted, event not occuring
            if (mercuryIsAfflicted) { return CalculatorResult.NotOccuring(); }

            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();

        }

        #endregion

        #region DEBUG

        //[EventCalculator(EventName.CustomEvent)]
        public static CalculatorResult IsCustomEventOccuring(Time time, Person person)
        {
            //good tarabala
            var goodTarabala = IsGoodTarabalaOccuring(time, person).Occuring;

            //good chandrabala
            var goodChandrabala = IsGoodChandrabalaOccuring(time, person).Occuring;

            //ugra yoga
            var ugraYoga = IsUgraYogaOccuring(time, person).Occuring;

            if (goodTarabala && goodChandrabala && ugraYoga)
            {
                return CalculatorResult.IsOccuring();
            }
            else
            {
                return CalculatorResult.NotOccuring();
            }

        }


        #endregion

        #region HOUSE
        //[EventCalculator(EventName.BadSunSignForHouseBuilding)]
        //public static Prediction IsKujasthamaOccuring(Time time, Person person)
        //{
        //    //The Sun should occupy fixed signs or
        //    // at least movable signs but no building work should be undertaken when
        //    // the Sun is in common signs.

        //    //get sign Sun is in
        //    var sunSignName = AstronomicalCalculator.GetSunSign(time);

        //    //check if sign is a common sign


        //    //if it is common sign



        //}



        #endregion

        #region MARRIAGE

        [EventCalculator(EventName.TaitulaKarana)]
        public static CalculatorResult IsTaitulaKaranaOccuring(Time time, Person person)
        {
            //Thaithula is propitious for marriage
            var karana = AstronomicalCalculator.GetKarana(time);

            //occuring if correct Karana
            var occuring = karana == Karana.Taitula;
            return new() { Occuring = occuring };

        }



        #endregion

        #region GENERAL

        [EventCalculator(EventName.SakunaKarana)]
        public static CalculatorResult IsSakunaKaranaOccuring(Time time, Person person)
        {
            //For getting initiations into mantras Sakuni Karana is propitious.   

            var karana = AstronomicalCalculator.GetKarana(time);

            //occuring if correct Karana
            var occuring = karana == Karana.Sakuna;
            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.BavaKarana)]
        public static CalculatorResult IsBavaKaranaOccuring(Time time, Person person)
        {
            //Thus Bava is auspicious for starting works of permanent importance while
            var karana = AstronomicalCalculator.GetKarana(time);

            //occuring if correct Karana
            var occuring = karana == Karana.Bava;
            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.BhadraKarana)]
        public static CalculatorResult IsBhadraKaranaOccuring(Time time, Person person)
        {
            //Bhadra is unfit for any good work but is eminently suitable for
            //violent and cruel deeds.

            var karana = AstronomicalCalculator.GetKarana(time);

            //occuring if correct Karana
            var occuring = karana == Karana.Visti;
            return new() { Occuring = occuring };

        }

        [EventCalculator(EventName.Ekadashi)]
        public static CalculatorResult IsEkadashiOccuring(Time time, Person person)
        {
            // It is the 11th tithi

            //get lunar day
            var lunarDayNumber = AstronomicalCalculator.GetLunarDay(time).GetLunarDayNumber();

            //right lunar days to look for
            var rightLunarDay = lunarDayNumber == 11;

            //if not correct lunar days, end here as not occuring
            if (rightLunarDay == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();

        }

        [EventCalculator(EventName.BhriguShatka)]
        public static CalculatorResult IsBhriguShatkaOccuring(Time time, Person person)
        {
            //The position of Venus in the 6th is injurious. This is
            // especially so in regard to marriage. Even when Venus is exalted and
            // associated with benefics, such a disposition is not approved.

            //get house venus is in
            var houseVenusIsIn = AstronomicalCalculator.GetHousePlanetIsIn(time, PlanetName.Venus);

            //if venus is in 6th house
            if (houseVenusIsIn == 6)
            {
                //event is occuring
                return CalculatorResult.IsOccuring();
            }
            else
            {
                //event is not occuring
                return CalculatorResult.NotOccuring();
            }


        }

        [EventCalculator(EventName.Kujasthama)]
        public static CalculatorResult IsKujasthamaOccuring(Time time, Person person)
        {

            //Mars should be avoided in the 8th house, as it
            // indicates destruction of the object in view. In a marriage election chart.
            // Mars in the 8th is unthinkable. Even if Mars is otherwise powerful, he
            // should not occupy the 8th house.

            //get house mars is in
            var houseMarsIsIn = AstronomicalCalculator.GetHousePlanetIsIn(time, PlanetName.Mars);

            //if mars is in 8th house
            if (houseMarsIsIn == 8)
            {
                //event is occuring
                return CalculatorResult.IsOccuring();
            }
            else
            {
                //event is not occuring
                return CalculatorResult.NotOccuring();
            }


        }

        [EventCalculator(EventName.KarthariDosha)]
        public static CalculatorResult IsKarthariDoshaOccuring(Time time, Person person)
        {
            //Karthari Dosha. - Karthari means scissors. In an election, when two
            // evil planets are placed on either side of the Lagna, the combination
            // goes under the special name of Karthari Dosha and it should be
            // rejected for good work particularly in regard to marriage.

            //get name of planets that are evil
            //Evil planets
            // Sun, New Moon (weak), Badly associated mercury, mars, saturn, rahu, ketu
            //

            //1.0 Get list of evil planets
            var listOfEvilPlanets = AstronomicalCalculator.GetMaleficPlanetList(time);

            //2.0 Check if evil planets are in house 12 & 2

            //mark evil planet not found in 12th house first
            var evilPlanetFoundInHouse12 = false;
            //mark evil planet not found in 2nd house first
            var evilPlanetFoundInHouse2 = false;

            //get planets in 12th house
            List<PlanetName> planetsInHouse12 = AstronomicalCalculator.GetPlanetsInHouse(12, time);

            //check if evil planets are found in house 12
            foreach (var planet in listOfEvilPlanets)
            {
                //if evil planet found, set flag
                evilPlanetFoundInHouse12 = planetsInHouse12.Contains(planet);

                //once evil planet found
                if (evilPlanetFoundInHouse12)
                {
                    //break loop, stop looking
                    break;
                }
            }

            //if evil planet found in house 12, check house 2 for evil planets
            if (evilPlanetFoundInHouse12)
            {
                //get planets in 2nd house
                List<PlanetName> planetsInHouse2 = AstronomicalCalculator.GetPlanetsInHouse(2, time);

                //check if evil planets are found in house 2
                foreach (var planet in listOfEvilPlanets)
                {
                    //if evil planet found, set flag
                    evilPlanetFoundInHouse2 = planetsInHouse2.Contains(planet);

                    //once evil planet found
                    if (evilPlanetFoundInHouse2)
                    {
                        //break loop, stop looking
                        break;
                    }
                }

            }

            //3.0 If evil planets found in both houses, event is occuring
            if (evilPlanetFoundInHouse12 && evilPlanetFoundInHouse2)
            {
                return CalculatorResult.IsOccuring();
            }
            else
            {
                //event not occuring
                return CalculatorResult.NotOccuring();
            }

        }

        [EventCalculator(EventName.ShashtashtaRiphagathaChandraDosha)]
        public static CalculatorResult IsShashtashtaRiphagathaChandraDoshaOccuring(Time time, Person person)
        {
            //Shashtashta Riphagatha Chandra Dosha. - The Moon should
            // invariably be avoided in the 6th, 8th and 12th houses from the Lagna
            // rising in an election chart.

            //get house moon is in
            var houseMoonIsIn = AstronomicalCalculator.GetHousePlanetIsIn(time, PlanetName.Moon);

            //if house moon is in is 6, 8 or 12
            if (houseMoonIsIn == 6 || houseMoonIsIn == 8 || houseMoonIsIn == 12)
            {
                //event is occuring
                return CalculatorResult.IsOccuring();
            }

            //else event is not occuring
            return CalculatorResult.NotOccuring();
        }

        [EventCalculator(EventName.SagrahaChandraDosha)]
        public static CalculatorResult IsSagrahaChandraDoshaOccuring(Time time, Person person)
        {
            //Sagraha Chandra Dosha. - The Moon's association (conjunction) with any other
            // planet, benefic or malefic, should be avoided. This injunction is specially
            // applicable in case of marriage.

            //get planets in conjunction with the moon
            var planetsInConjunct = AstronomicalCalculator.GetPlanetsInConjuction(time, PlanetName.Moon);

            //if any planets are in conjunct with moon, event is occuring
            if (planetsInConjunct.Count > 0) { return CalculatorResult.IsOccuring(); }

            return CalculatorResult.NotOccuring();
        }

        [EventCalculator(EventName.UdayasthaSuddhi)]
        public static CalculatorResult IsUdayasthaSuddhiOccuring(Time time, Person person)
        {

            //6. Udayasta Suddhi. - The Lagna and the seventh should be strong.
            // The Lagna should be occupied by its own lord and the Navamsa Lagna
            // by its own lord or vice versa or lord of Lagna should aspect Navamsa
            // Lagna and vice versa. Similarly the seventh and the lord of the seventh
            // Bhava should be favourably disposed. The strength of Lagna and the
            // seventh is necessary in all elections but especially so in regard to
            // marriage.

            //TODO NOTE : Below reference can be used but not sure.
            //"Jupiter, Mercury or Venus in Lagna, malefics in the 3rd or 11th, would
            // constitute a formidable force in rendering the Lagna strong."

            //Note : "Strength" here is determined based on the rules above only, (shadbala is not used)

            //check if lagna is strong
            var lagnaIsStrong = IsStrongLagnaOccuring(time);

            //if lagna is NOT strong, end here as not occuring
            if (!lagnaIsStrong) { return CalculatorResult.NotOccuring(); }

            //check if 7th is strong
            var house7IsStrong = IsStrongHouse7Occuring(time);


            //ocurring if lagna & house 7 is strong
            var occuring = lagnaIsStrong && house7IsStrong;
            return new() { Occuring = occuring };




            //-----------------------------------------FUNCTIONS--------------------------------


            //strenght here is based on rules above
            //Note : not 100% sure if strenght calculated here can be used else where
            bool IsStrongLagnaOccuring(Time time)
            {
                // 1. The Lagna should be occupied by its own lord and the Navamsa Lagna
                // by its own lord or vice versa or lord of Lagna should aspect Navamsa
                // Lagna and vice versa.

                //Note 3 possible condition for event

                //POSSIBLE 1
                //1.1 Lagna occupied by Lagna Lord
                bool lagnaLordInLagna = AstronomicalCalculator.IsHouseLordInHouse(HouseName.House1, HouseName.House1, time);

                //1.2 Navamsa lagna occupied Navamsa Lagna Lord
                bool navamsaLagnaLordInNavamsaLagna = IsNavamsaLagnaLordInNavamsaLagnaOccuring(time);

                if (lagnaLordInLagna && navamsaLagnaLordInNavamsaLagna)
                {
                    //event is occuring
                    return true;
                }

                //POSSIBLE 2
                //1.3 Lagna occupied by Navamsa Lagna Lord
                bool navamsaLagnaLordInLagna = IsNavamsaLagnaLordInLagna(time);

                //1.4 Navamsa lagna occupied by Lagna Lord
                bool lagnaLordInNavamsaLagna = IsLagnaLordInNavamsaLagnaOccuring(time);

                if (navamsaLagnaLordInLagna && lagnaLordInNavamsaLagna)
                {
                    //event is occuring
                    return true;
                }

                //POSSIBLE 3
                //lord of Lagna should aspect Navamsa Lagna
                bool lordOfLagnaAspectsNavamsaLagna = IsLagnaLordAspectingNavamsaLagnaOccuring(time);

                //1.6 lord of Navamsa Lagna should aspect Lagna
                bool lordOfNavamsaLagnaAspectsLagna = IsNavamsaLagnaLordAspectingLagna(time);

                if (lordOfLagnaAspectsNavamsaLagna && lordOfNavamsaLagnaAspectsLagna)
                {
                    //event is occuring
                    return true;
                }

                //if no above condition met, event not occuring
                return false;
            }

            //strenght here is based on rules above
            //Note : not 100% sure if strenght calculated here can be used else where
            bool IsStrongHouse7Occuring(Time time)
            {

                //Note 3 possible condition for event


                //POSSIBLE 1
                //7th occupied by 7th Lord
                bool _7thLordIn7th = AstronomicalCalculator.IsHouseLordInHouse(HouseName.House7, HouseName.House7, time);

                //Navamsa 7th occupied Navamsa 7th Lord
                bool navamsa7thLordInNavamsa7th = IsNavamsa7thLordInNavamsa7thOccuring(time);

                if (_7thLordIn7th && navamsa7thLordInNavamsa7th)
                {
                    //event is occuring
                    return true;
                }


                //POSSIBLE 2
                //7th occupied by Navamsa 7th Lord
                bool navamsa7thLordIn7th = IsNavamsa7thLordIn7th(time);

                //Navamsa 7th occupied by 7th Lord
                bool _7thLordInNavamsa7th = Is7thLordInNavamsa7thOccuring(time);

                if (navamsa7thLordIn7th && _7thLordInNavamsa7th)
                {
                    //event is occuring
                    return true;
                }


                //POSSIBLE 3
                //lord of 7th should aspect Navamsa 7th
                bool lordOf7thAspectsNavamsa7th = Is7thLordAspectingNavamsa7thOccuring(time);

                //lord of Navamsa Lagna should aspect Lagna
                bool lordOfNavamsaLagnaAspectsLagna = IsNavamsa7thLordAspecting7th(time);

                if (lordOf7thAspectsNavamsa7th && lordOfNavamsaLagnaAspectsLagna)
                {
                    //event is occuring
                    return true;
                }

                //if no above condition met, event not occuring
                return false;
            }

            bool IsNavamsaLagnaLordAspectingLagna(Time time)
            {
                //1.0 get navamsa lagna lord
                //1.1 get navamsa lagna sign
                var navamsaLagnaSign = AstronomicalCalculator.GetHouseNavamsaSign(HouseName.House1, time);

                var navamsaLagnaLord = AstronomicalCalculator.GetLordOfZodiacSign(navamsaLagnaSign);

                //2.0 get signs navamsa lagna lord is aspecting
                var signsNavamsaLagnaLordIsAspecting =
                    AstronomicalCalculator.GetSignsPlanetIsAspecting(navamsaLagnaLord, time);

                //3.0 get sign of lagna
                var lagnaSign = AstronomicalCalculator.GetHouseSignName(1, time);

                //4.0 check if lagna is in one of the signs navamsa lagna lord is aspecting
                if (signsNavamsaLagnaLordIsAspecting.Contains(lagnaSign))
                {
                    //event is occuring
                    return true;
                }
                else
                {
                    return false;
                }

            }

            bool IsNavamsa7thLordAspecting7th(Time time)
            {
                //1.0 get navamsa 7th lord
                //1.1 get navamsa 7th sign
                var navamsa7thSign = AstronomicalCalculator.GetHouseNavamsaSign(HouseName.House7, time);

                var navamsa7thLord = AstronomicalCalculator.GetLordOfZodiacSign(navamsa7thSign);

                //2.0 get signs navamsa 7th lord is aspecting
                var signsNavamsa7thLordIsAspecting =
                    AstronomicalCalculator.GetSignsPlanetIsAspecting(navamsa7thLord, time);

                //3.0 get sign of 7th
                var _7thSign = AstronomicalCalculator.GetHouseSignName(7, time);

                //4.0 check if 7th is in one of the signs navamsa 7th lord is aspecting
                if (signsNavamsa7thLordIsAspecting.Contains(_7thSign))
                {
                    //event is occuring
                    return true; ;
                }
                else
                {
                    return false;
                }

            }

            bool IsLagnaLordAspectingNavamsaLagnaOccuring(Time time)
            {
                //1.0 gets sign navamsa lord is aspecting
                //get lagna lord (house 1)
                var lagnaLord = AstronomicalCalculator.GetLordOfHouse(HouseName.House1, time);

                //get signs lagna lord is aspecting
                var signsLagnaLordIsAspecting = AstronomicalCalculator.GetSignsPlanetIsAspecting(lagnaLord, time);

                //2.0 get navamsa lagna sign
                //get navamsa lagna at house 1 longitude
                var navamsaLagnaSign = AstronomicalCalculator.GetHouseNavamsaSign(HouseName.House1, time);

                //3.0
                //check if navamsa lagna is one of the signs lagna lord is aspecting
                if (signsLagnaLordIsAspecting.Contains(navamsaLagnaSign))
                {
                    //event is occuring
                    return true; ;
                }
                else
                {
                    return false;
                }

            }

            bool Is7thLordAspectingNavamsa7thOccuring(Time time)
            {
                //1.0 gets sign navamsa lord is aspecting
                //get 7th lord
                var _7thLord = AstronomicalCalculator.GetLordOfHouse(HouseName.House7, time);

                //get signs 7th lord is aspecting
                var signs7thLordIsAspecting = AstronomicalCalculator.GetSignsPlanetIsAspecting(_7thLord, time);

                //2.0 get navamsa 7th sign
                var navamsa7thSign = AstronomicalCalculator.GetHouseNavamsaSign(HouseName.House7, time);

                //3.0
                //check if navamsa 7th is one of the signs 7th lord is aspecting
                if (signs7thLordIsAspecting.Contains(navamsa7thSign))
                {
                    //event is occuring
                    return true; ;
                }
                else
                {
                    return false;
                }

            }

            bool IsNavamsaLagnaLordInLagna(Time time)
            {
                //1.0 get navamsa lagna sign
                //get navamsa lagna at house 1 longitude
                var navamsaLagnaSign = AstronomicalCalculator.GetHouseNavamsaSign(HouseName.House1, time);

                //2.0 Get navamsa lagna lord's current sign
                //get navamsa lagna lord (planet)
                var navamsaLagnaLord = AstronomicalCalculator.GetLordOfZodiacSign(navamsaLagnaSign);

                //get ordinary sign of navamsa lagna lord
                var ordinarySignOfNavamsaLagnaLord = AstronomicalCalculator.GetPlanetRasiSign(navamsaLagnaLord, person.BirthTime).GetSignName();

                //3.0 Get sign of house 1
                var house1Sign = AstronomicalCalculator.GetHouseSignName(1, time);

                //check if house 1 sign is same sign as the one navamsa lagna lord is in
                if (house1Sign == ordinarySignOfNavamsaLagnaLord)
                {
                    //event occuring
                    return true; ;
                }
                else
                {
                    return false;
                }

            }

            /// <summary>
            /// TODO : Needs validation
            /// </summary>
            bool IsNavamsa7thLordIn7th(Time time)
            {
                //1.0 get navamsa 7th sign
                var navamsa7thSign = AstronomicalCalculator.GetHouseNavamsaSign(HouseName.House7, time);

                //2.0 Get navamsa 7th lord's current sign
                //get navamsa 7th lord (planet)
                var navamsa7thLord = AstronomicalCalculator.GetLordOfZodiacSign(navamsa7thSign);

                //get ordinary sign of navamsa 7th lord
                var ordinarySignOfNavamsa7thLord = AstronomicalCalculator.GetPlanetRasiSign(navamsa7thLord, person.BirthTime).GetSignName();

                //3.0 Get sign of house 7
                var house7Sign = AstronomicalCalculator.GetHouseSignName(7, time);

                //check if house 7 sign is same sign as the one navamsa 7th lord is in
                if (house7Sign == ordinarySignOfNavamsa7thLord)
                {
                    //event occuring
                    return true; ;
                }
                else
                {
                    return false;
                }

            }

            bool IsLagnaLordInNavamsaLagnaOccuring(Time time)
            {
                //1.0 Get
                //get lord of house 1 (lagna)
                var lagnaLord = AstronomicalCalculator.GetLordOfHouse(HouseName.House1, time);

                //get navamsa sign of lagna lord
                var navamsaSignOfLagnaLord = AstronomicalCalculator.GetPlanetNavamsaSign(lagnaLord, time);

                //2.0 get navamsa lagna sign
                //get navamsa lagna at house 1 longitude
                var navamsaLagnaSign = AstronomicalCalculator.GetHouseNavamsaSign(HouseName.House1, time);

                //3.0 check if lagna lord in navamsa lagna sign
                if (navamsaSignOfLagnaLord == navamsaLagnaSign)
                {
                    //event is occuring
                    return true; ;
                }
                else
                {
                    return false;
                }

            }

            bool Is7thLordInNavamsa7thOccuring(Time time)
            {
                //1.0 Get
                //get lord of house 7
                var _7thLord = AstronomicalCalculator.GetLordOfHouse(HouseName.House7, time);

                //get navamsa sign of 7th lord
                var navamsaSignOf7thLord = AstronomicalCalculator.GetPlanetNavamsaSign(_7thLord, time);

                //2.0 get navamsa 7th sign
                var navamsa7thSign = AstronomicalCalculator.GetHouseNavamsaSign(HouseName.House7, time);

                //3.0 check if 7th lord in navamsa 7th sign
                if (navamsaSignOf7thLord == navamsa7thSign)
                {
                    //event is occuring
                    return true; ;
                }
                else
                {
                    return false;
                }

            }

            bool IsNavamsaLagnaLordInNavamsaLagnaOccuring(Time time)
            {

                //1.0 get navamsa lagna sign
                //get navamsa lagna at house 1 longitude
                var navamsaLagnaSign = AstronomicalCalculator.GetHouseNavamsaSign(HouseName.House1, time);

                //2.0 Get navamsa lagna lord's current sign
                //get navamsa lagna lord (planet)
                var navamsaLagnaLord = AstronomicalCalculator.GetLordOfZodiacSign(navamsaLagnaSign);

                //get navamsa sign of navamsa lagna lord
                var navamsaSignOfNavamsaLagnaLord = AstronomicalCalculator.GetPlanetNavamsaSign(navamsaLagnaLord, time);

                //3.0
                //check if lagna lord is in navamsa lagna sign
                if (navamsaSignOfNavamsaLagnaLord == navamsaLagnaSign)
                {
                    //event is occuring
                    return true; ;
                }
                else
                {
                    return false;
                }
            }

            bool IsNavamsa7thLordInNavamsa7thOccuring(Time time)
            {

                //1.0 get 7th house navamsa sign
                var navamsa7thSign = AstronomicalCalculator.GetHouseNavamsaSign(HouseName.House7, time);

                //2.0 Get navamsa 7th lord's current sign
                //get navamsa 7th lord (planet)
                var navamsa7thLord = AstronomicalCalculator.GetLordOfZodiacSign(navamsa7thSign);

                //get navamsa sign of navamsa 7th lord
                var navamsaSignOfNavamsa7thLord = AstronomicalCalculator.GetPlanetNavamsaSign(navamsa7thLord, time);

                //3.0
                //check if 7th lord is in navamsa 7th sign
                if (navamsaSignOfNavamsa7thLord == navamsa7thSign)
                {
                    //event is occuring
                    return true; ;
                }
                else
                {
                    return false;
                }
            }

        }

        [EventCalculator(EventName.LagnaThyajya)]
        public static CalculatorResult IsLagnaThyajyaOccuring(Time time, Person person)
        {

            //get house 1 middle longitude
            var house1MiddleLongitude = AstronomicalCalculator.GetHouse(HouseName.House1, time).GetMiddleLongitude();

            //get zodiac sign at lagna (middle longitude)
            var house1ZodiacSign = AstronomicalCalculator.GetZodiacSignAtLongitude(house1MiddleLongitude);

            var house1SignName = house1ZodiacSign.GetSignName();
            var house1DegreesInSign = house1ZodiacSign.GetDegreesInSign().TotalDegrees;

            //In Aries, Taurus, Sagittarius and Virgo, the first three degrees should be
            // avoided as it is supposed to be in the nature of a serpent (bhujanga)
            // and hence destructive.
            if (house1SignName == ZodiacName.Aries || house1SignName == ZodiacName.Taurus ||
                house1SignName == ZodiacName.Sagittarius || house1SignName == ZodiacName.Virgo)
            {
                if (house1DegreesInSign >= 0 && house1DegreesInSign < 4)
                {
                    return CalculatorResult.IsOccuring();
                }
                else
                {
                    return CalculatorResult.NotOccuring();
                }

            }


            //In regard to Pisces, Capricorn, Cancer and Scorpio, the last (three degrees) (27 to 30)
            //has to be avoided as it is supposed to be presided over by the evil force of Rahu.
            if (house1SignName == ZodiacName.Pisces || house1SignName == ZodiacName.Capricornus ||
                house1SignName == ZodiacName.Cancer || house1SignName == ZodiacName.Scorpio)
            {
                if (house1DegreesInSign >= 27 && house1DegreesInSign <= 30)
                {
                    return CalculatorResult.IsOccuring();
                }
                else
                {
                    return CalculatorResult.NotOccuring();
                }

            }

            // The middle half ghati (13°30' to 16° 30') should be rejected with
            // regard to Gemini, Libra, Leo and Aquarius
            // as it is ruled by an evil force termed Gridhra.
            if (house1SignName == ZodiacName.Gemini || house1SignName == ZodiacName.Libra ||
                house1SignName == ZodiacName.Leo || house1SignName == ZodiacName.Aquarius)
            {
                if (house1DegreesInSign >= 13.50 && house1DegreesInSign <= 16.50)
                {
                    return CalculatorResult.IsOccuring();
                }
                else
                {
                    return CalculatorResult.NotOccuring();
                }

            }

            //if no condition above met, event not occuring
            return CalculatorResult.NotOccuring();

        }

        [EventCalculator(EventName.NotAuspiciousDay)]
        public static CalculatorResult IsNotAuspiciousDayOccuring(Time time, Person person)
        {
            //Tuesday and Saturday should be avoided for all good and-auspicious works
            //Tuesday is not evil after midday

            //get current weekday
            var weekday = AstronomicalCalculator.GetDayOfWeek(time);

            //if tuesday & after midday then not occuring, end here
            if (weekday == DayOfWeek.Tuesday && isAfterMidday()) { return CalculatorResult.NotOccuring(); }

            //if tuesday or saturday event occuring
            if (weekday == DayOfWeek.Tuesday || weekday == DayOfWeek.Saturday) { return CalculatorResult.IsOccuring(); }

            //if control reaches here, not occuring
            return CalculatorResult.NotOccuring();

            //------------FUNCTIONS
            bool isAfterMidday()
            {
                //get current apparent time
                var localApparentTime = AstronomicalCalculator.GetLocalApparentTime(time);
                //get apparent noon
                var apparentNoon = AstronomicalCalculator.GetNoonTime(time);

                //if current time is past noon, then occuring
                return localApparentTime > apparentNoon;
            }
        }

        [EventCalculator(EventName.GoodPlanetsInLagna)]
        public static CalculatorResult IsGoodPlanetsInLagnaOccuring(Time time, Person person)
        {
            //Venus, Mercury or Jupiter in the ascendant will completely destroy all
            //other adverse influences

            //get planets in 1st house (ascendant)
            var planetsInLagna = AstronomicalCalculator.GetPlanetsInHouse(1, time);

            //list of good planets to look for
            var goodList = new List<PlanetName>() { PlanetName.Venus, PlanetName.Mercury, PlanetName.Jupiter };

            foreach (var planetName in planetsInLagna)
            {
                //if planet is good one, event is occuring
                if (goodList.Contains(planetName)) { return CalculatorResult.IsOccuring(); }
            }

            //if control reaches here, event not occuring
            return CalculatorResult.NotOccuring();
        }

        [EventCalculator(EventName.GoodPlanetsIn11th)]
        public static CalculatorResult IsGoodPlanetsIn11thOccuring(Time time, Person person)
        {
            //The mere presence of the Moon or the Sun in the 11th will act as an
            // antidote for other evils obtaining in the horoscope

            //get planets in 11st house 
            var planetsIn11th = AstronomicalCalculator.GetPlanetsInHouse(11, time);

            //list of good planets to look for
            var goodList = new List<PlanetName>() { PlanetName.Moon, PlanetName.Sun };

            foreach (var planetName in planetsIn11th)
            {
                //if planet is found good list, event is occuring
                if (goodList.Contains(planetName)) { return CalculatorResult.IsOccuring(); }
            }

            //if control reaches here, event not occuring
            return CalculatorResult.NotOccuring();
        }

        [EventCalculator(EventName.GoodPlanetsInKendra)]
        public static CalculatorResult IsGoodPlanetsInKendraOccuring(Time time, Person person)
        {
            //Jupiter or Venus in a kendra (quadrant/angles) and malefics in 3, 6 or 11
            //will remove all the flaws arising on account of unfavourable weekday,
            //constellation, lunar day and yoga.

            //Note: Planets in angles (kendra) generally become fairly strong


            //1
            //check if Jupiter or Venus in a kendra (quadrant)
            var planetInKendra = AstronomicalCalculator.IsPlanetInKendra(PlanetName.Jupiter, time) ||
                                 AstronomicalCalculator.IsPlanetInKendra(PlanetName.Venus, time);

            //if neither planet in kendra, end here as not occuring
            if (planetInKendra == false) { return CalculatorResult.NotOccuring(); }


            //2
            var maleficsIn3rd6th11th = isAllMaleficsIn3rd6th11th();

            //if all melefics are NOT in 3,6,11, end here as not occuring
            if (maleficsIn3rd6th11th == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here, event is occuring
            return CalculatorResult.IsOccuring();


            //---------------FUNCTIONS-----

            //returns true if all malefics is contained in 3,6 or 11th house, false otherwise
            bool isAllMaleficsIn3rd6th11th()
            {
                //get all malefic planets
                var allMalefics = AstronomicalCalculator.GetMaleficPlanetList(time);

                //go through each malefic planet and
                //make sure each is in 3, 6 or 11th house
                foreach (var malefic in allMalefics)
                {
                    var planetHouse = AstronomicalCalculator.GetHousePlanetIsIn(time, malefic);

                    //if not in 3, 6 or 11, end here as not occuring
                    if (!(planetHouse == 3 || planetHouse == 6 || planetHouse == 11)) { return false; }
                }

                //if control reaches here, than it is occuring
                return true;
            }

        }

        [EventCalculator(EventName.GoodRullingConstellation)]
        public static CalculatorResult IsGoodRullingConstellationOccuring(Time time, Person person)
        {
            //Pushya rulling is a constellation par excellence that could
            //be universally employed for all purposes, excepting of course marriage

            //1. Constellation
            //get ruling constellation
            var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

            //check ruling constellation name
            var rightConstellation = rulingConstellationName == ConstellationName.Pushyami;

            //if not correct constellation, end here as not occuring
            if (rightConstellation == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();

        }

        [EventCalculator(EventName.BadRullingConstellation)]
        public static CalculatorResult IsBadRullingConstellationOccuring(Time time, Person person)
        {

            //Certain constellations, apart from their being harmonious or otherwise disposed
            //with reference to one's own Janma Nakshatra, should be avoided for
            //certain specific purposes on account of their inherent evil natures. In
            //fact, Bharani is condemned for all good work and it has to be
            //scrupulously avoided for all good work.

            //When a constellation like
            //Bharani(beta Arietis) is held to be constitutionally unfit for certain types
            //of elections; it means that the vibrations emanating from it are
            //destructive in character

            //Of the several Nakshatras, Bharani and Krittika
            // should be avoided for all auspicious works as these two are said to be
            // presided over by the god of death (Yama) and the god of fire (Agni)
            // respectively. In urgent cases if the Lagna could be fortified, the dosha
            // due to nakshatra may get neutralised. The last parts of Aslesha,
            // Jyeshta and Revati should also be avoided.


            //1. Constellation
            //get ruling constellation
            var rulingConstellation = AstronomicalCalculator.GetMoonConstellation(time);
            var rulingConstellationName = rulingConstellation.GetConstellationName();


            if (rulingConstellationName == ConstellationName.Bharani || rulingConstellationName == ConstellationName.Krithika)
            {
                //event occuring
                return CalculatorResult.IsOccuring();
            }


            if (rulingConstellationName == ConstellationName.Aslesha || rulingConstellationName == ConstellationName.Jyesta
                                                                     || rulingConstellationName == ConstellationName.Revathi)
            {
                if (rulingConstellation.GetQuarter() == 4)
                {
                    //event occuring
                    return CalculatorResult.IsOccuring();
                }

            }



            //if control reaches here then event is NOT occuring
            return CalculatorResult.NotOccuring();

        }

        [EventCalculator(EventName.SiddhaYoga)]
        public static CalculatorResult IsSiddhaYogaOccuring(Time time, Person person)
        {
            var siddhaYogaMonday = IsSiddhaYogaMondayOccuring(time, person);
            var siddhaYogaTuesday = IsSiddhaYogaTuesdayOccuring(time, person);
            var siddhaYogaWednesday = IsSiddhaYogaWednesdayOccuring(time, person);
            var siddhaYogaThursday = IsSiddhaYogaThursdayOccuring(time, person);
            var siddhaYogaFriday = IsSiddhaYogaFridayOccuring(time, person);
            var siddhaYogaSaturday = IsSiddhaYogaSaturdayOccuring(time, person);
            var siddhaYogaSunday = IsSiddhaYogaSundayOccuring(time, person);

            if (siddhaYogaMonday || siddhaYogaTuesday || siddhaYogaWednesday || siddhaYogaThursday ||
                siddhaYogaFriday || siddhaYogaSaturday || siddhaYogaSunday)
            {
                return CalculatorResult.IsOccuring();
            }
            else
            {
                return CalculatorResult.NotOccuring();
            }


            //NOTE : All sidhha yoga since same, under 1 name
            bool IsSiddhaYogaSundayOccuring(Time time, Person person)
            {
                //Sunday coinciding with the 1st, 4th, 6th, 7th or 12th lunar day and ruled
                // by the constellations Pushya, Hasta, Uttara, Uttarashadha, Moola,
                // Sravana or Uttarabhadra gives rise to Siddha Yoga.
                //

                //get weekday
                var dayOfWeek = AstronomicalCalculator.GetDayOfWeek(time);
                //get lunar day
                var lunarDayNumber = AstronomicalCalculator.GetLunarDay(time).GetLunarDayNumber();
                //get ruling constellation
                var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

                //check day of week
                if (dayOfWeek == DayOfWeek.Sunday)
                {
                    //check lunar day number
                    if (lunarDayNumber == 1 || lunarDayNumber == 4 ||
                        lunarDayNumber == 6 || lunarDayNumber == 7 ||
                        lunarDayNumber == 12)
                    {
                        //check ruling constellation name
                        if (rulingConstellationName == ConstellationName.Pushyami ||
                            rulingConstellationName == ConstellationName.Hasta ||
                            rulingConstellationName == ConstellationName.Uttara ||
                            rulingConstellationName == ConstellationName.Uttarashada ||
                            rulingConstellationName == ConstellationName.Moola ||
                            rulingConstellationName == ConstellationName.Sravana ||
                            rulingConstellationName == ConstellationName.Uttarashada)
                        {
                            return true;
                        }
                    }
                }

                //if none of the conditions above are met return false
                return false;
            }

            bool IsSiddhaYogaMondayOccuring(Time time, Person person)
            {
                //Monday identical with the 2nd, 7th or 12th lunar day and with the
                // constellations Rohini, Mrigasira, Punarvasu, Chitta, Sravana,
                // Satabhisha, Dhanishta or Poorvabhadra produces Siddha Yoga.

                //get weekday
                var dayOfWeek = AstronomicalCalculator.GetDayOfWeek(time);
                //get lunar day
                var lunarDayNumber = AstronomicalCalculator.GetLunarDay(time).GetLunarDayNumber();
                //get ruling constellation
                var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

                //check day of week
                if (dayOfWeek == DayOfWeek.Monday)
                {
                    //check lunar day number
                    if (lunarDayNumber == 2 || lunarDayNumber == 7 ||
                        lunarDayNumber == 12)
                    {
                        //check ruling constellation name
                        if (rulingConstellationName == ConstellationName.Rohini ||
                            rulingConstellationName == ConstellationName.Mrigasira ||
                            rulingConstellationName == ConstellationName.Punarvasu ||
                            rulingConstellationName == ConstellationName.Chitta ||
                            rulingConstellationName == ConstellationName.Sravana ||
                            rulingConstellationName == ConstellationName.Satabhisha ||
                            rulingConstellationName == ConstellationName.Dhanishta ||
                            rulingConstellationName == ConstellationName.Poorvabhadra)
                        {
                            return true;
                        }
                    }
                }

                //if none of the conditions above are met return false
                return false;
            }

            bool IsSiddhaYogaTuesdayOccuring(Time time, Person person)
            {
                //Tuesday falling on a day ruled by Aswini, Mrigasira, Chitta, Anuradha,
                // Moola, Uttara, Dhanishta or Poorvabhadra gives rise to Siddha Yoga.
                //OR
                //Tuesday coinciding with Jaya (3rd 8th and 13th lunar days)

                //get weekday
                var dayOfWeek = AstronomicalCalculator.GetDayOfWeek(time);
                //get lunar day
                var lunarDayGroup = AstronomicalCalculator.GetLunarDay(time).GetLunarDayGroup();
                //get ruling constellation
                var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

                //check day of week
                if (dayOfWeek == DayOfWeek.Tuesday)
                {
                    //check ruling constellation name
                    if (rulingConstellationName == ConstellationName.Aswini ||
                        rulingConstellationName == ConstellationName.Mrigasira ||
                        rulingConstellationName == ConstellationName.Chitta ||
                        rulingConstellationName == ConstellationName.Anuradha ||
                        rulingConstellationName == ConstellationName.Moola ||
                        rulingConstellationName == ConstellationName.Uttara ||
                        rulingConstellationName == ConstellationName.Dhanishta ||
                        rulingConstellationName == ConstellationName.Poorvabhadra)
                    {
                        return true;
                    }

                    //check lunar day group
                    if (lunarDayGroup == LunarDayGroup.Jaya)
                    {
                        return true;
                    }

                }

                //if none of the conditions above are met return false
                return false;
            }

            bool IsSiddhaYogaWednesdayOccuring(Time time, Person person)
            {
                //Wednesday coinciding with Bhadra and Jaya and with the constellations
                // Rohini, Mrigasira, Aridra, Uttara, Uttarashadha or Anuradha generates
                // Siddha Yoga.
                //OR
                //Wednesday identical with Bhadra (2nd, 7th and 12th lunar days),

                //get weekday
                var dayOfWeek = AstronomicalCalculator.GetDayOfWeek(time);
                //get lunar day
                var lunarDayGroup = AstronomicalCalculator.GetLunarDay(time).GetLunarDayGroup();
                //get ruling constellation
                var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

                //check day of week
                if (dayOfWeek == DayOfWeek.Wednesday)
                {
                    //check lunar day group
                    if (lunarDayGroup == LunarDayGroup.Bhadra || lunarDayGroup == LunarDayGroup.Jaya)
                    {
                        //check ruling constellation name
                        if (rulingConstellationName == ConstellationName.Rohini ||
                            rulingConstellationName == ConstellationName.Mrigasira ||
                            rulingConstellationName == ConstellationName.Aridra ||
                            rulingConstellationName == ConstellationName.Uttara ||
                            rulingConstellationName == ConstellationName.Uttarashada ||
                            rulingConstellationName == ConstellationName.Anuradha)
                        {
                            return true;
                        }
                    }

                    //check lunar day group
                    if (lunarDayGroup == LunarDayGroup.Bhadra)
                    {
                        return true;
                    }
                }

                //if none of the conditions above are met return false
                return false;
            }

            bool IsSiddhaYogaThursdayOccuring(Time time, Person person)
            {
                //Thursday identical with the 4th, 5th, 7th, 9th, 13th or 14th lunar day and
                // with tne asterisms Makha, Pushya, Punarvasu, Swati. Poorvashadha,
                // Poorvabhadra, Revati or Aswini gives rise to Siddha Yoga.
                //OR
                //Thursday falling on 5th, 10th or 15th(Poorna)

                //get weekday
                var dayOfWeek = AstronomicalCalculator.GetDayOfWeek(time);
                //get lunar day
                var lunarDayNumber = AstronomicalCalculator.GetLunarDay(time).GetLunarDayNumber();
                //get lunar day
                var lunarDayGroup = AstronomicalCalculator.GetLunarDay(time).GetLunarDayGroup();
                //get ruling constellation
                var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

                //check day of week
                if (dayOfWeek == DayOfWeek.Thursday)
                {
                    //check lunar day number
                    if (lunarDayNumber == 4 || lunarDayNumber == 5 ||
                        lunarDayNumber == 7 || lunarDayNumber == 9 ||
                        lunarDayNumber == 13 || lunarDayNumber == 14)
                    {
                        //check ruling constellation name
                        if (rulingConstellationName == ConstellationName.Makha ||
                            rulingConstellationName == ConstellationName.Pushyami ||
                            rulingConstellationName == ConstellationName.Punarvasu ||
                            rulingConstellationName == ConstellationName.Swathi ||
                            rulingConstellationName == ConstellationName.Poorvashada ||
                            rulingConstellationName == ConstellationName.Poorvabhadra ||
                            rulingConstellationName == ConstellationName.Revathi ||
                            rulingConstellationName == ConstellationName.Aswini)
                        {
                            return true;
                        }
                    }

                    //check lunar day group
                    if (lunarDayGroup == LunarDayGroup.Purna)
                    {
                        return true;
                    }

                }

                //if none of the conditions above are met return false
                return false;
            }

            bool IsSiddhaYogaFridayOccuring(Time time, Person person)
            {
                //Friday ruled by Aswini, Bharani, Aridra, Uttara, Chitta, Swati,
                // Poorvashadha or Revati coinciding with Nanda and Bhadra constitutes
                // this beneficial yoga.
                // OR
                //A Friday coinciding with Nanda (1st, 6th and 11th lunar days)


                //get weekday
                var dayOfWeek = AstronomicalCalculator.GetDayOfWeek(time);
                //get lunar day group
                var lunarDayGroup = AstronomicalCalculator.GetLunarDay(time).GetLunarDayGroup();
                //get ruling constellation
                var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

                //check day of week
                if (dayOfWeek == DayOfWeek.Friday)
                {
                    //check lunar day group
                    if (lunarDayGroup == LunarDayGroup.Bhadra || lunarDayGroup == LunarDayGroup.Nanda)
                    {
                        //check ruling constellation name
                        if (rulingConstellationName == ConstellationName.Aswini ||
                            rulingConstellationName == ConstellationName.Bharani ||
                            rulingConstellationName == ConstellationName.Aridra ||
                            rulingConstellationName == ConstellationName.Uttara ||
                            rulingConstellationName == ConstellationName.Chitta ||
                            rulingConstellationName == ConstellationName.Swathi ||
                            rulingConstellationName == ConstellationName.Poorvashada ||
                            rulingConstellationName == ConstellationName.Revathi)
                        {
                            return true;
                        }
                    }

                    //check lunar day group
                    if (lunarDayGroup == LunarDayGroup.Nanda)
                    {
                        return true;
                    }
                }

                //if none of the conditions above are met return false
                return false;
            }

            bool IsSiddhaYogaSaturdayOccuring(Time time, Person person)
            {
                //Saturday falling on a day ruled by Swati, Rohini, Visakha, Anuradha,
                // Dhanishta or Satabhisha and with lunar days Bhadra and Riktha
                // generates the same auspicious yoga.
                //OR
                //Saturday falling on a Riktha tithi(4th, 9th and 14th lunar days)

                //get weekday
                var dayOfWeek = AstronomicalCalculator.GetDayOfWeek(time);
                //get lunar day
                var lunarDayGroup = AstronomicalCalculator.GetLunarDay(time).GetLunarDayGroup();
                //get ruling constellation
                var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

                //check day of week
                if (dayOfWeek == DayOfWeek.Saturday)
                {
                    //check lunar day group
                    if (lunarDayGroup == LunarDayGroup.Bhadra || lunarDayGroup == LunarDayGroup.Rikta)
                    {
                        //check ruling constellation name
                        if (rulingConstellationName == ConstellationName.Swathi ||
                            rulingConstellationName == ConstellationName.Rohini ||
                            rulingConstellationName == ConstellationName.Vishhaka ||
                            rulingConstellationName == ConstellationName.Anuradha ||
                            rulingConstellationName == ConstellationName.Dhanishta ||
                            rulingConstellationName == ConstellationName.Satabhisha)
                        {
                            return true;
                        }
                    }

                    //check lunar day group
                    if (lunarDayGroup == LunarDayGroup.Rikta)
                    {
                        return true;
                    }
                }

                //if none of the conditions above are met return false
                return false;
            }
        }

        [EventCalculator(EventName.AmritaSiddhaYoga)]
        public static CalculatorResult IsAmritaSiddhaYogaOccuring(Time time, Person person)
        {
            //Sunday to Saturday respectively coinciding with the constellations
            // Hasta(Sunday), Sravana(Monday), Aswini(Tuesday), Anuradha(Wednesday), Pushya(Thursday), Revati(Friday) and Rohini(Saturday) will give
            // rise to Amita Siddha Yoga.

            //get weekday
            var dayOfWeek = AstronomicalCalculator.GetDayOfWeek(time);
            //get ruling constellation
            var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

            //check day of week
            if (dayOfWeek == DayOfWeek.Sunday)
            {
                //check ruling constellation name
                if (rulingConstellationName == ConstellationName.Hasta)
                {
                    return CalculatorResult.IsOccuring();
                }
            }

            //check day of week
            if (dayOfWeek == DayOfWeek.Monday)
            {
                //check ruling constellation name
                if (rulingConstellationName == ConstellationName.Sravana)
                {
                    return CalculatorResult.IsOccuring();
                }
            }

            //check day of week
            if (dayOfWeek == DayOfWeek.Tuesday)
            {
                //check ruling constellation name
                if (rulingConstellationName == ConstellationName.Aswini)
                {
                    return CalculatorResult.IsOccuring();
                }
            }

            //check day of week
            if (dayOfWeek == DayOfWeek.Wednesday)
            {
                //check ruling constellation name
                if (rulingConstellationName == ConstellationName.Anuradha)
                {
                    return CalculatorResult.IsOccuring();
                }
            }

            //check day of week
            if (dayOfWeek == DayOfWeek.Thursday)
            {
                //check ruling constellation name
                if (rulingConstellationName == ConstellationName.Pushyami)
                {
                    return CalculatorResult.IsOccuring();
                }
            }

            //check day of week
            if (dayOfWeek == DayOfWeek.Friday)
            {
                //check ruling constellation name
                if (rulingConstellationName == ConstellationName.Revathi)
                {
                    return CalculatorResult.IsOccuring();
                }
            }

            //check day of week
            if (dayOfWeek == DayOfWeek.Saturday)
            {
                //check ruling constellation name
                if (rulingConstellationName == ConstellationName.Rohini)
                {
                    return CalculatorResult.IsOccuring();
                }
            }


            //if none of the conditions above are met return false
            return CalculatorResult.NotOccuring();
        }

        [EventCalculator(EventName.PanchangaSuddhi)]
        public static CalculatorResult IsPanchangaSuddhiOccuring(Time time, Person person)
        {
            //TODO Needs to be fixed

            //We have already said that a Panchanga
            // consists of tithi, vara, nakshatra. yoga and karana. All these must be
            // auspicious.
            // - In regard to lunar days, the 4th, 6th, 8th, 12th and 14th, full
            // and new moon days should be avoided.

            //get lunar day
            var lunarDayNumber = AstronomicalCalculator.GetLunarDay(time).GetLunarDayNumber();

            if (lunarDayNumber == 4 || lunarDayNumber == 6
                || lunarDayNumber == 8 || lunarDayNumber == 12
                || lunarDayNumber == 14 || lunarDayNumber == 15 || lunarDayNumber == 1)
            {
                return CalculatorResult.NotOccuring();
            }

            //
            // - In regard to vara, Thursday and Friday are held to be suitable for all works. Tuesday, is to be generally
            // avoided except when it happens to be the 10th, 12th or 16th day of the
            // child's birth when the child's Namakarana (baptising or giving name)
            // may be performed.
            //

            //get weekday
            var dayOfWeek = AstronomicalCalculator.GetDayOfWeek(time);

            if (dayOfWeek != DayOfWeek.Thursday || dayOfWeek != DayOfWeek.Friday)
            {
                return CalculatorResult.NotOccuring();
            }

            // - Of the several Nakshatras, Bharani and Krittika
            // should be avoided for all auspicious works as these two are said to be
            // presided over by the god of death (Yama) and the god of fire (Agni)
            //respectively. In urgent cases if the Lagna could be fortified, the dosha
            // due to nakshatra may get neutralised. The last parts of Aslesha,
            // Jyeshta and Revati should also be avoided.

            //get ruling constellation
            var rulingConstellation = AstronomicalCalculator.GetMoonConstellation(time);
            var rulingConstellationName = rulingConstellation.GetConstellationName();

            if (rulingConstellationName == ConstellationName.Bharani || rulingConstellationName == ConstellationName.Krithika)
            {
                return CalculatorResult.NotOccuring();
            }

            if (rulingConstellationName == ConstellationName.Aslesha || rulingConstellationName == ConstellationName.Jyesta
                || rulingConstellationName == ConstellationName.Revathi)
            {
                if (rulingConstellation.GetQuarter() == 4)
                {
                    return CalculatorResult.NotOccuring();
                }

            }


            //
            // - Coming to the Yoga the 6th (Atiganda). 9th (Soola). 10th (Ganda), 17th (Vyatipata)
            // and 27th (Vydhruti) have deleterious effects upon events which are
            // started or commenced under them. -

            var yoga = AstronomicalCalculator.GetNithyaYoga(time);

            if (yoga == NithyaYoga.Atiganda || yoga == NithyaYoga.Soola
                || yoga == NithyaYoga.Ganda || yoga == NithyaYoga.Vyatapata
                || yoga == NithyaYoga.Vaidhriti)
            {
                return CalculatorResult.NotOccuring();
            }

            //
            // - Karana chosen must be appropriate to the election in view.
            // Thus Bava is auspicious for starting works of permanent importance
            // while Thaithula is propitious for marriage.
            // Bhadra(vishti) is unfit for any good work but is eminently suitable for violent and cruel deeds.
            // For getting initiation into kshudra mantras Sakuni Havana is propitious.

            var karana = AstronomicalCalculator.GetKarana(time);
            //all karana mentioned are included
            if (karana != Karana.Bava || karana != Karana.Taitula || karana != Karana.Visti || karana != Karana.Sakuna)
            {
                return CalculatorResult.NotOccuring();
            }

            // Therefore, Panchanga Suddhi means a good lunar day, a beneficial
            // weekday, an auspicious constellation, a good yoga and a fertilising
            // Karana.

            return CalculatorResult.IsOccuring();

        }

        [EventCalculator(EventName.BadNithyaYoga)]
        public static CalculatorResult IsBadNithyaYogaOccuring(Time time, Person person)
        {
            // - Coming to the Yoga the 6th (Atiganda). 9th (Soola). 10th (Ganda), 17th (Vyatipata)
            // and 27th (Vydhruti) have deleterious effects upon events which are
            // started or commenced under them. -

            var yoga = AstronomicalCalculator.GetNithyaYoga(time);

            if (yoga == NithyaYoga.Atiganda || yoga == NithyaYoga.Soola
                                            || yoga == NithyaYoga.Ganda || yoga == NithyaYoga.Vyatapata
                                            || yoga == NithyaYoga.Vaidhriti)
            {
                return CalculatorResult.IsOccuring();
            }
            else
            {
                return CalculatorResult.NotOccuring();
            }

        }

        [EventCalculator(EventName.SuryaSankramana)]
        public static CalculatorResult IsSuryaSankramanaOccuring(Time time, Person person)
        {
            //Surya Sankramana. - The 2nd great evil is Surya Sankramana or the
            // solar ingress into different zodiacal signs. When the Sun is about to
            // leave one sign and enter another there seem to occur certain
            // disturbances in the organisation of the solar forces and such times are
            // not recommended for any good work. On the contrary, they are held to
            // be propitious for meditation, initiation into secret mantras and
            // performance of certain religious rites which are held to purify not only
            // the bodily electrical discharges but also the mental currents. Sixteen
            // ghatis (6 hours 24 minutes) both before and after the entry of the Sun
            // into a new sign should be rejected for all new works.

            //hours to reject (6 hours 24 minutes / 6.4 hours)
            const double hoursToReject = 6.4;

            //get time sun entered into current sign
            var timeSunEnteredCurrentSign = AstronomicalCalculator.GetTimeSunEnteredCurrentSign(time);

            //get hours after entry into sign
            var hoursAfterEntryIntoSign = time.Subtract(timeSunEnteredCurrentSign).TotalHours;

            //if hours after entry is less than or equals hours to reject
            if (hoursAfterEntryIntoSign <= hoursToReject)
            {
                //return true
                return CalculatorResult.IsOccuring();
            }


            //get time sun will leave current sign
            var timeSunLeavesCurrentSign = AstronomicalCalculator.GetTimeSunLeavesCurrentSign(time);

            //get hours before entry into new sign
            var hoursBeforeEntryIntoSign = timeSunLeavesCurrentSign.Subtract(time).TotalHours;

            //if hours before entry is less than or equals hours to reject
            if (hoursBeforeEntryIntoSign <= hoursToReject)
            {
                //return true
                return CalculatorResult.IsOccuring();
            }


            //if no conditions met return false
            return CalculatorResult.NotOccuring();
        }

        [EventCalculator(EventName.Papashadvargas)]
        public static CalculatorResult IsPapashadvargasOccuring(Time time, Person person)
        {
            //TODO ALWAYS ON
            //DISABLE FOR NOW
            return CalculatorResult.NotOccuring();


            //Papashadvargs. - Malefics should not be strong in shadvargas in an election chart.
            //This event idicates that malefics are strong in shadvargas

            //TODO Note : It is possible that overall strenght of a malefic is considered,
            //            for now not 100% sure. Current method of using shadvarga bala calculation
            //            seems workable. Further verification is in order.
            //            Shadvarga bala uses malefic's relationship with sign to determine strenght

            //get all malefic planets
            var allMalefics = AstronomicalCalculator.GetMaleficPlanetList(time);

            //rahu & ketu are not included
            //TODO needs checking
            allMalefics.RemoveAll(name => name == PlanetName.Rahu || name == PlanetName.Ketu);

            //go through each malefic planet and
            //check if is strong in shadvarga
            foreach (var malefic in allMalefics)
            {
                //check if planet is strong
                var isStrong = AstronomicalCalculator.IsPlanetStrongInShadvarga(malefic, time);

                //if any one malefic is strong, end here as occuring
                if (isStrong) { return CalculatorResult.IsOccuring(); }

            }

            //if control reaches here, than it is NOT occuring
            return CalculatorResult.NotOccuring();

        }

        #endregion

        #region HAIR AND NAIL

        [EventCalculator(EventName.GoodHairCutting)]
        public static CalculatorResult IsGoodHairCuttingOccuring(Time time, Person person)
        {
            //1. Shaving may be had in the constellation of Pushya, Punarvasu, Revat,
            //  Haste, Sravana, Dhanishta, Mrigasira, Aswini, Chitta, Jyeshta,
            //  Satabhisha and Swati

            //get ruling constellation
            var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

            //check ruling constellation name
            var correctConstellation = rulingConstellationName == ConstellationName.Pushyami ||
                    rulingConstellationName == ConstellationName.Punarvasu ||
                    rulingConstellationName == ConstellationName.Revathi ||
                    rulingConstellationName == ConstellationName.Hasta ||
                    rulingConstellationName == ConstellationName.Sravana ||
                    rulingConstellationName == ConstellationName.Dhanishta ||
                    rulingConstellationName == ConstellationName.Mrigasira ||
                    rulingConstellationName == ConstellationName.Aswini ||
                    rulingConstellationName == ConstellationName.Chitta ||
                    rulingConstellationName == ConstellationName.Jyesta ||
                    rulingConstellationName == ConstellationName.Satabhisha ||
                    rulingConstellationName == ConstellationName.Swathi;

            //if not correct constellation, end here as not occuring
            if (correctConstellation == false) { return CalculatorResult.NotOccuring(); }


            //2. 4th, 6th and 14th lunar days as also New Moon
            //   and Full Moon days are not desirable

            //get lunar day
            var lunarDayNumber = AstronomicalCalculator.GetLunarDay(time).GetLunarDayNumber();

            //lunar days to avoid
            var avoidLunarDay = lunarDayNumber == 4 ||
                                  lunarDayNumber == 6 ||
                                  lunarDayNumber == 14 ||
                                  lunarDayNumber == 1 || //new moon
                                  lunarDayNumber == 15; //full moon

            //if the lunar days to avoid are occuring, end here as not occuring
            if (avoidLunarDay == true) { return CalculatorResult.NotOccuring(); }


            //if conrtol reaches here then event is ocuring
            return CalculatorResult.IsOccuring();

        }

        [EventCalculator(EventName.GoodNailCutting)]
        public static CalculatorResult IsGoodNailCuttingOccuring(Time time, Person person)
        {
            //Avoid Fridays and Saturdays - 


            //get weekday
            var dayOfWeek = AstronomicalCalculator.GetDayOfWeek(time);

            //check if days to avoid are occuring
            var avoidDays = dayOfWeek == DayOfWeek.Friday || dayOfWeek == DayOfWeek.Saturday;

            //if wrong days then, end here as not occuring
            if (avoidDays == true) { return CalculatorResult.NotOccuring(); }



            //Avoid the 8th, 9th, 14th lunar
            //days as well as New and Full Moon days.

            //get lunar day
            var lunarDayNumber = AstronomicalCalculator.GetLunarDay(time).GetLunarDayNumber();

            //lunar days to avoid
            var avoidLunarDay = lunarDayNumber == 8 ||
                                lunarDayNumber == 9 ||
                                lunarDayNumber == 14 ||
                                lunarDayNumber == 1 || //new moon
                                lunarDayNumber == 15; //full moon

            //if the lunar days to avoid are occuring, end here as not occuring
            if (avoidLunarDay == true) { return CalculatorResult.NotOccuring(); }


            //if conrtol reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }


        #endregion

        #region RULLING CONSTLLATION

        [EventCalculator(EventName.FixedConstellationRuling)]
        public static CalculatorResult IsFixedConstellationRulingOccuring(Time time, Person person)
        {
            //Rohini, Uttara, -Uttamsliadka and Ufctarabhadra
            //are supposed to be fixed constellations
            //and they are favourable' for coronations, laying"
            //the foundation of cities, sowing operations,,
            //planting trees and other permanent things.


            //get ruling constellation
            var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

            //check ruling constellation name
            var fixedConstellation = rulingConstellationName == ConstellationName.Rohini ||
                                       rulingConstellationName == ConstellationName.Uttara ||
                                       rulingConstellationName == ConstellationName.Uttarashada ||
                                       rulingConstellationName == ConstellationName.Uttarabhadra;

            //if not correct constellation, end here as not occuring
            if (fixedConstellation == false) { return CalculatorResult.NotOccuring(); }


            //if conrtol reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.SoftConstellationRuling)]
        public static CalculatorResult IsSoftConstellationRulingOccuring(Time time, Person person)
        {
            //Chitta, Anuradha, Mrigasira and Revati are soft constellations. They are
            //good for wearing new apparel, learning dancing, music and fine arts,
            //sexual union and performance of auspicious ceremonies.


            //get ruling constellation
            var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

            //check ruling constellation name
            var softConstellation = rulingConstellationName == ConstellationName.Chitta ||
                                       rulingConstellationName == ConstellationName.Anuradha ||
                                       rulingConstellationName == ConstellationName.Mrigasira ||
                                       rulingConstellationName == ConstellationName.Revathi;

            //if not correct constellation, end here as not occuring
            if (softConstellation == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.LightConstellationRuling)]
        public static CalculatorResult IsLightConstellationRulingOccuring(Time time, Person person)
        {

            //Aswini, Pushya, Hasta and Abhijit are light constellations, and they can
            //be selected for putting ornamentation, pleasures and sports,
            //administering medicine, starting industries and undertaking travels.


            //get ruling constellation
            var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

            //check ruling constellation name
            var lightConstellation = rulingConstellationName == ConstellationName.Aswini ||
                                       rulingConstellationName == ConstellationName.Pushyami ||
                                       rulingConstellationName == ConstellationName.Hasta;

            //if not correct constellation, end here as not occuring
            if (lightConstellation == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.SharpConstellationRuling)]
        public static CalculatorResult IsSharpConstellationRulingOccuring(Time time, Person person)
        {
            //Moola, Jyestha, Aridra and Aslesha are sharp in nature and they are
            //favourable for incantations, invoking spirits, for imprisonment, murders,
            //and separation of friends.

            //get ruling constellation
            var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

            //check ruling constellation name
            var sharpConstellation = rulingConstellationName == ConstellationName.Moola ||
                                       rulingConstellationName == ConstellationName.Jyesta ||
                                       rulingConstellationName == ConstellationName.Aridra ||
                                       rulingConstellationName == ConstellationName.Aslesha;

            //if not correct constellation, end here as not occuring
            if (sharpConstellation == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.MovableConstellationRuling)]
        public static CalculatorResult IsMovableConstellationRulingOccuring(Time time, Person person)
        {
            //Saravana, Dhanishta, Satabhisha, Punarvasu and Swati are movable
            //stars and they are auspicious fcr acquiring vehicles, for gardening and
            //for going on procession.

            //get ruling constellation
            var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

            //check ruling constellation name
            var movableConstellation = rulingConstellationName == ConstellationName.Sravana ||
                                       rulingConstellationName == ConstellationName.Dhanishta ||
                                       rulingConstellationName == ConstellationName.Satabhisha ||
                                       rulingConstellationName == ConstellationName.Punarvasu ||
                                       rulingConstellationName == ConstellationName.Swathi;

            //if not correct constellation, end here as not occuring
            if (movableConstellation == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.DreadfulConstellationRuling)]
        public static CalculatorResult IsDreadfulConstellationRulingOccuring(Time time, Person person)
        {
            //Pubba, Poorvashadha and Poorvabhadra, Bharani and Makha are
            //dreadful stars and they are suitable for nefarious schemes, poisoning,
            //deceit, imprisonment, setting fire and other evil deeds.

            //get ruling constellation
            var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

            //check ruling constellation name
            var dreadfulConstellation = rulingConstellationName == ConstellationName.Pubba ||
                                        rulingConstellationName == ConstellationName.Poorvashada ||
                                        rulingConstellationName == ConstellationName.Poorvabhadra ||
                                        rulingConstellationName == ConstellationName.Bharani ||
                                        rulingConstellationName == ConstellationName.Makha;

            //if not correct constellation, end here as not occuring
            if (dreadfulConstellation == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.MixedConstellationRuling)]
        public static CalculatorResult IsMixedConstellationRulingOccuring(Time time, Person person)
        {
            //Krittika and Visakha are mixed constellations and during their
            //influences, works of day-to-day importance can be undertaken.

            //get ruling constellation
            var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

            //check ruling constellation name
            var mixedConstellation = rulingConstellationName == ConstellationName.Krithika ||
                                     rulingConstellationName == ConstellationName.Vishhaka;

            //if not correct constellation, end here as not occuring
            if (mixedConstellation == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }


        #endregion

        #region AGRICULTURE

        [EventCalculator(EventName.GoodAnySeedsSowing)]
        public static CalculatorResult IsGoodAnySeedsSowingOccuring(Time time, Person person)
        {
            //Sowing : Any seeds can be sown on a day ruled by Hasta,
            //Chitta, Swati, Makha, Pushyami, Uttara, Uttarashadha, Uttarabhadra,
            //Rohini, Revati, Aswini, Moola or Anuradha provided the lunar day is
            //also propitious. Choose a Lagna, owned by the planet who is lord of the
            //weekday in question.


            //1. General good yoga for planting
            var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

            //if not right, end here as not occuring
            if (rightYoga == false) { return CalculatorResult.NotOccuring(); }


            //2. Constellation
            //get ruling constellation
            var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

            //check ruling constellation name
            var rightConstellation = rulingConstellationName == ConstellationName.Hasta ||
                                     rulingConstellationName == ConstellationName.Chitta ||
                                     rulingConstellationName == ConstellationName.Swathi ||
                                     rulingConstellationName == ConstellationName.Makha ||
                                     rulingConstellationName == ConstellationName.Pushyami ||
                                     rulingConstellationName == ConstellationName.Uttara ||
                                     rulingConstellationName == ConstellationName.Uttarashada ||
                                     rulingConstellationName == ConstellationName.Uttarabhadra ||
                                     rulingConstellationName == ConstellationName.Rohini ||
                                     rulingConstellationName == ConstellationName.Revathi ||
                                     rulingConstellationName == ConstellationName.Aswini ||
                                     rulingConstellationName == ConstellationName.Moola ||
                                     rulingConstellationName == ConstellationName.Anuradha;

            //if not correct constellation, end here as not occuring
            if (rightConstellation == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();

        }

        [EventCalculator(EventName.GoodForPlantingTrees)]
        public static CalculatorResult IsGoodForPlantingTreesOccuring(Time time, Person person)
        {
            //good for trees in Rohini

            //1. General good yoga for planting
            var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

            //if not right, end here as not occuring
            if (rightYoga == false) { return CalculatorResult.NotOccuring(); }


            //2. Constellation
            //get ruling constellation
            var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

            //check ruling constellation name
            var rightConstellation = rulingConstellationName == ConstellationName.Rohini;

            //if not correct constellation, end here as not occuring
            if (rightConstellation == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();

        }

        [EventCalculator(EventName.GoodForPlantingFlowerSeeds)]
        public static CalculatorResult IsGoodForPlantingFlowerSeedsOccuring(Time time, Person person)
        {
            //Seeds of flower plants, and fruit-bearing creepers should be sown in the asterisms in 
            //Mriyusira, Punarvasu, Hasta, Chitta, Swati, Anuradha and Revati


            //1. General good yoga for planting
            var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

            //if not right, end here as not occuring
            if (rightYoga == false) { return CalculatorResult.NotOccuring(); }


            //2. Constellation
            //get ruling constellation
            var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

            //check ruling constellation name
            var rightConstellation = rulingConstellationName == ConstellationName.Mrigasira ||
                                     rulingConstellationName == ConstellationName.Punarvasu ||
                                     rulingConstellationName == ConstellationName.Hasta ||
                                     rulingConstellationName == ConstellationName.Chitta ||
                                     rulingConstellationName == ConstellationName.Swathi ||
                                     rulingConstellationName == ConstellationName.Anuradha ||
                                     rulingConstellationName == ConstellationName.Revathi;


            //if not correct constellation, end here as not occuring
            if (rightConstellation == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();

        }

        [EventCalculator(EventName.GoodForPlantingSugarcane)]
        public static CalculatorResult IsGoodForPlantingSugarcaneOccuring(Time time, Person person)
        {
            //Sugarcane in Punarvasu

            //1. General good yoga for planting
            var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

            //if not right, end here as not occuring
            if (rightYoga == false) { return CalculatorResult.NotOccuring(); }


            //2. Constellation
            //get ruling constellation
            var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

            //check ruling constellation name
            var rightConstellation = rulingConstellationName == ConstellationName.Punarvasu;

            //if not correct constellation, end here as not occuring
            if (rightConstellation == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();

        }

        [EventCalculator(EventName.GoodForPlantingFruitTrees)]
        public static CalculatorResult IsGoodForPlantingFruitTreesOccuring(Time time, Person person)
        {

            //if either 1 event is occuring
            if (fruitTree1() || fruitTree2())
            {
                return CalculatorResult.IsOccuring();
            }
            else
            {
                return CalculatorResult.NotOccuring();
            }

            //Seedlings of long-lived fruit trees when Jupiter is in Lagna on Thursday
            bool fruitTree1()
            {

                //1. General good yoga for planting
                var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

                //if not right, end here as not occuring
                if (rightYoga == false) { return false; }


                //3. Weekday
                //get current weekday
                var currentWeekday = AstronomicalCalculator.GetDayOfWeek(time);

                //check weekday
                var rightWeekday = currentWeekday == DayOfWeek.Thursday;

                //if not correct weekday, end here as not occuring
                if (rightWeekday == false) { return false; }


                //2. Jupiter is in Lagna
                //get planets in lagna 
                var currentPlanetsInLagna = AstronomicalCalculator.GetPlanetsInHouse(1, time);

                //check if jupiter is in lagna
                var rightPlanet = currentPlanetsInLagna.Contains(PlanetName.Jupiter);

                //if not correct planet, end here as not occurings
                if (rightPlanet == false) { return false; }


                //if control reaches here then event is ocuring
                return true;

            }

            //fruit trees may be planted when Sagittarius and Pisces are rising on Thursday
            bool fruitTree2()
            {
                //1. General good yoga for planting
                var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

                //if not right, end here as not occuring
                if (rightYoga == false) { return false; }


                //3. Weekday
                //get current weekday
                var currentWeekday = AstronomicalCalculator.GetDayOfWeek(time);

                //check weekday
                var rightWeekday = currentWeekday == DayOfWeek.Thursday;

                //if not correct weekday, end here as not occuring
                if (rightWeekday == false) { return false; }


                //2. Correct rising sign
                //get rising sign
                var risingSign = AstronomicalCalculator.GetHouseSignName(1, time);

                //check rising sign
                var rightSign = risingSign == ZodiacName.Sagittarius ||
                                risingSign == ZodiacName.Pisces;

                //if not correct sign, end here as not occuring
                if (rightSign == false) { return false; }



                //if control reaches here then event is ocuring
                return true;

            }
        }

        [EventCalculator(EventName.GoodForPlantingFlowerTrees)]
        public static CalculatorResult IsGoodForPlantingFlowerTreesOccuring(Time time, Person person)
        {
            //Seedlings of flower trees when Venus is in Lagna on Friday


            //1. General good yoga for planting
            var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

            //if not right, end here as not occuring
            if (rightYoga == false) { return CalculatorResult.NotOccuring(); }


            //3. Weekday
            //get current weekday
            var currentWeekday = AstronomicalCalculator.GetDayOfWeek(time);

            //check weekday
            var rightWeekday = currentWeekday == DayOfWeek.Friday;

            //if not correct weekday, end here as not occuring
            if (rightWeekday == false) { return CalculatorResult.NotOccuring(); }


            //2. Planet is in Lagna
            //get planets in lagna 
            var currentPlanetsInLagna = AstronomicalCalculator.GetPlanetsInHouse(1, time);

            //check if correct planet is in lagna
            var rightPlanet = currentPlanetsInLagna.Contains(PlanetName.Venus);

            //if not correct planet, end here as not occurings
            if (rightPlanet == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();

        }

        [EventCalculator(EventName.GoodForPlantingFlowers)]
        public static CalculatorResult IsGoodForPlantingFlowersOccuring(Time time, Person person)
        {
            //Seedlings of flower sown when Mars is in Lagna on Tuesday


            //1. General good yoga for planting
            var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

            //if not right, end here as not occuring
            if (rightYoga == false) { return CalculatorResult.NotOccuring(); }


            //3. Weekday
            //get current weekday
            var currentWeekday = AstronomicalCalculator.GetDayOfWeek(time);

            //check weekday
            var rightWeekday = currentWeekday == DayOfWeek.Tuesday;

            //if not correct weekday, end here as not occuring
            if (rightWeekday == false) { return CalculatorResult.NotOccuring(); }


            //2. Planet is in Lagna
            //get planets in lagna 
            var currentPlanetsInLagna = AstronomicalCalculator.GetPlanetsInHouse(1, time);

            //check if correct planet is in lagna
            var rightPlanet = currentPlanetsInLagna.Contains(PlanetName.Mars);

            //if not correct planet, end here as not occurings
            if (rightPlanet == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();

        }

        [EventCalculator(EventName.GoodForPlantingFlowerCuttings)]
        public static CalculatorResult IsGoodForPlantingFlowerCuttingsOccuring(Time time, Person person)
        {
            //Flower seeds and cuttings may be sown when Taurus or Libra rising


            //1. General good yoga for planting
            var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

            //if not right, end here as not occuring
            if (rightYoga == false) { return CalculatorResult.NotOccuring(); }


            //2. Correct rising sign
            //get rising sign
            var risingSign = AstronomicalCalculator.GetHouseSignName(1, time);

            //check rising sign
            var rightSign = risingSign == ZodiacName.Taurus ||
                            risingSign == ZodiacName.Libra;

            //if not correct sign, end here as not occuring
            if (rightSign == false) { return CalculatorResult.NotOccuring(); }



            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();

        }

        [EventCalculator(EventName.GoodForPlantingFloweringPlants)]
        public static CalculatorResult IsGoodForPlantingFloweringPlantsOccuring(Time time, Person person)
        {
            //Flowering plants in Virgo

            //1. General good yoga for planting
            var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

            //if not right, end here as not occuring
            if (rightYoga == false) { return CalculatorResult.NotOccuring(); }


            //2. Correct rising sign
            //get rising sign
            var risingSign = AstronomicalCalculator.GetHouseSignName(1, time);

            //check rising sign
            var rightSign = risingSign == ZodiacName.Virgo;

            //if not correct sign, end here as not occuring
            if (rightSign == false) { return CalculatorResult.NotOccuring(); }

            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.GoodForPlantingGarlic)]
        public static CalculatorResult IsGoodForPlantingGarlicOccuring(Time time, Person person)
        {
            //Garlic in Aries

            //1. General good yoga for planting
            var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

            //if not right, end here as not occuring
            if (rightYoga == false) { return CalculatorResult.NotOccuring(); }


            //2. Correct rising sign
            //get rising sign
            var risingSign = AstronomicalCalculator.GetHouseSignName(1, time);

            //check rising sign
            var rightSign = risingSign == ZodiacName.Aries;

            //if not correct sign, end here as not occuring
            if (rightSign == false) { return CalculatorResult.NotOccuring(); }

            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.GoodForPlantingPeachAndOthers)]
        public static CalculatorResult IsGoodForPlantingPeachAndOthersOccuring(Time time, Person person)
        {
            //Peach, plum, potatoes, radishes, onion sets and turnips in Taurus

            //1. General good yoga for planting
            var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

            //if not right, end here as not occuring
            if (rightYoga == false) { return CalculatorResult.NotOccuring(); }


            //2. Correct rising sign
            //get rising sign
            var risingSign = AstronomicalCalculator.GetHouseSignName(1, time);

            //check rising sign
            var rightSign = risingSign == ZodiacName.Taurus;

            //if not correct sign, end here as not occuring
            if (rightSign == false) { return CalculatorResult.NotOccuring(); }

            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.GoodForPlantingTomatoesAndOthers)]
        public static CalculatorResult IsGoodForPlantingTomatoesAndOthersOccuring(Time time, Person person)
        {
            //Beans, cabbage, corn, cucumber, lettuce, melons, pumpkins, tomatoes, cauliflower, water-melons, and cereals in Cancer

            //1. General good yoga for planting
            var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

            //if not right, end here as not occuring
            if (rightYoga == false) { return CalculatorResult.NotOccuring(); }


            //2. Correct rising sign
            //get rising sign
            var risingSign = AstronomicalCalculator.GetHouseSignName(1, time);

            //check rising sign
            var rightSign = risingSign == ZodiacName.Cancer;

            //if not correct sign, end here as not occuring
            if (rightSign == false) { return CalculatorResult.NotOccuring(); }

            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.GoodForPlantingGrains)]
        public static CalculatorResult IsGoodForPlantingGrainsOccuring(Time time, Person person)
        {
            //wheat, rye, barley, rice and other field crops in Libra

            //1. General good yoga for planting
            var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

            //if not right, end here as not occuring
            if (rightYoga == false) { return CalculatorResult.NotOccuring(); }


            //2. Correct rising sign
            //get rising sign
            var risingSign = AstronomicalCalculator.GetHouseSignName(1, time);

            //check rising sign
            var rightSign = risingSign == ZodiacName.Libra;

            //if not correct sign, end here as not occuring
            if (rightSign == false) { return CalculatorResult.NotOccuring(); }

            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.GoodForPlantingOnionAndOthers)]
        public static CalculatorResult IsGoodForPlantingOnionAndOthersOccuring(Time time, Person person)
        {
            //Garlic and onion seeds in Scorpio

            //1. General good yoga for planting
            var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

            //if not right, end here as not occuring
            if (rightYoga == false) { return CalculatorResult.NotOccuring(); }


            //2. Correct rising sign
            //get rising sign
            var risingSign = AstronomicalCalculator.GetHouseSignName(1, time);

            //check rising sign
            var rightSign = risingSign == ZodiacName.Scorpio;

            //if not correct sign, end here as not occuring
            if (rightSign == false) { return CalculatorResult.NotOccuring(); }

            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.GoodForPlantingPepperAndOthers)]
        public static CalculatorResult IsGoodForPlantingPepperAndOthersOccuring(Time time, Person person)
        {
            //Pepper and other spring crops and garlic in Sagittarius

            //1. General good yoga for planting
            var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

            //if not right, end here as not occuring
            if (rightYoga == false) { return CalculatorResult.NotOccuring(); }


            //2. Correct rising sign
            //get rising sign
            var risingSign = AstronomicalCalculator.GetHouseSignName(1, time);

            //check rising sign
            var rightSign = risingSign == ZodiacName.Sagittarius;

            //if not correct sign, end here as not occuring
            if (rightSign == false) { return CalculatorResult.NotOccuring(); }

            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.GoodForPlantingPotatoAndOthers)]
        public static CalculatorResult IsGoodForPlantingPotatoAndOthersOccuring(Time time, Person person)
        {
            //Potato, radishes and turnips in Capricorn

            //1. General good yoga for planting
            var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

            //if not right, end here as not occuring
            if (rightYoga == false) { return CalculatorResult.NotOccuring(); }


            //2. Correct rising sign
            //get rising sign
            var risingSign = AstronomicalCalculator.GetHouseSignName(1, time);

            //check rising sign
            var rightSign = risingSign == ZodiacName.Capricornus;

            //if not correct sign, end here as not occuring
            if (rightSign == false) { return CalculatorResult.NotOccuring(); }

            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.GoodForPlantingGrainsAndOthers)]
        public static CalculatorResult IsGoodForPlantingGrainsAndOthersOccuring(Time time, Person person)
        {
            //All black cereals and grains in Aquarius

            //1. General good yoga for planting
            var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

            //if not right, end here as not occuring
            if (rightYoga == false) { return CalculatorResult.NotOccuring(); }


            //2. Correct rising sign
            //get rising sign
            var risingSign = AstronomicalCalculator.GetHouseSignName(1, time);

            //check rising sign
            var rightSign = risingSign == ZodiacName.Aquarius;

            //if not correct sign, end here as not occuring
            if (rightSign == false) { return CalculatorResult.NotOccuring(); }

            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.GoodForPlantingPumpkinsAndOthers)]
        public static CalculatorResult IsGoodForPlantingPumpkinsAndOthersOccuring(Time time, Person person)
        {
            //Cucumbers, pumpkins, radishes, water-melons and carrots in Pisces

            //1. General good yoga for planting
            var rightYoga = IsGoodYogaForAllAgricultureOccuring(time, person).Occuring;

            //if not right, end here as not occuring
            if (rightYoga == false) { return CalculatorResult.NotOccuring(); }


            //2. Correct rising sign
            //get rising sign
            var risingSign = AstronomicalCalculator.GetHouseSignName(1, time);

            //check rising sign
            var rightSign = risingSign == ZodiacName.Pisces;

            //if not correct sign, end here as not occuring
            if (rightSign == false) { return CalculatorResult.NotOccuring(); }

            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.GoodYogaForAllAgriculture)]
        public static CalculatorResult IsGoodYogaForAllAgricultureOccuring(Time time, Person person)
        {
            //1. Lunar Day
            //provided the lunar day is also propitious.

            //right lunar days for agriculture occuring
            var rightLunarDay = IsGoodLunarDayAgricultureOccuring(time, person).Occuring;

            //if not correct lunar days, end here as not occuring
            if (rightLunarDay == false) { return CalculatorResult.NotOccuring(); }


            //2. Lagna Lord
            //Choose a Lagna, owned by the planet who is lord of the weekday in question.
            var lagnaLordIsWeekdayLord = IsLagnaLordIsWeekdayLordOccuring(time, person).Occuring;

            //if not correct lagna, end here as not occuring
            if (lagnaLordIsWeekdayLord == false) { return CalculatorResult.NotOccuring(); }


            //3. House
            //While beginning all agricultural operations, see that the 8th house is unoccupied
            var house8Occupied = IsBadForStartingAllAgricultureOccuring(time, person).Occuring;

            //if 8th house is occupied, end here as not occuring
            if (house8Occupied == true) { return CalculatorResult.NotOccuring(); }


            //4. Rising Sign
            //Gemini: Not favourable for any planting being a barren sign.
            //Leo: Not good for any planting, especially bad for underground plants such as potato.
            var badRising = IsBadLagnaForAllAgricultureOccuring(time, person).Occuring;

            //if bad rising sign, end here as not occuring
            if (badRising == true) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.BadForStartingAllAgriculture)]
        public static CalculatorResult IsBadForStartingAllAgricultureOccuring(Time time, Person person)
        {
            //While beginning all agricultural operations, see that the 8th house is unoccupied

            //get all planets in 8th house
            var planets = AstronomicalCalculator.GetPlanetsInHouse(8, time);

            //if any planets in 8th house, return occuring
            if (planets.Any())
            {
                return CalculatorResult.IsOccuring();
            }
            else
            {   //if no planets, event not occuring
                return CalculatorResult.NotOccuring();
            }
        }

        [EventCalculator(EventName.LagnaLordIsWeekdayLord)]
        public static CalculatorResult IsLagnaLordIsWeekdayLordOccuring(Time time, Person person)
        {
            //Lagna owned by the planet who is lord of the weekday in question

            //get lord of lagna
            var lagnaLord = AstronomicalCalculator.GetLordOfHouse(HouseName.House1, time);

            //get lord of weekday
            var weekdayLord = AstronomicalCalculator.GetLordOfWeekday(time);


            //if the lord of lagna & lord of weekday same, then event occuring
            if (weekdayLord == lagnaLord)
            {
                return CalculatorResult.IsOccuring();
            }
            else
            {   //event not occuring, if planet not same
                return CalculatorResult.NotOccuring();
            }
        }

        [EventCalculator(EventName.GoodLunarDayAgriculture)]
        public static CalculatorResult IsGoodLunarDayAgricultureOccuring(Time time, Person person)
        {
            //All odd lunar days except the 9th are good.All even tithis except the
            //2nd and 4th should be avoided.
            //Thus: 1,2,3,4,5,7,11,13,15


            //get lunar day
            var lunarDayNumber = AstronomicalCalculator.GetLunarDay(time).GetLunarDayNumber();

            //right lunar days to look for
            var rightLunarDay = lunarDayNumber == 1 ||
                                lunarDayNumber == 2 ||
                                lunarDayNumber == 3 ||
                                lunarDayNumber == 4 ||
                                lunarDayNumber == 5 ||
                                lunarDayNumber == 7 ||
                                lunarDayNumber == 11 ||
                                lunarDayNumber == 13 ||
                                lunarDayNumber == 15; //full moon

            //if not correct lunar days, end here as not occuring
            if (rightLunarDay == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.BadLagnaForAllAgriculture)]
        public static CalculatorResult IsBadLagnaForAllAgricultureOccuring(Time time, Person person)
        {
            //Gemini: Not favourable for any planting being a barren sign.
            //Leo: Not good for any planting, especially bad for underground plants such as potato.

            //get rising sign
            var risingSign = AstronomicalCalculator.GetHouseSignName(1, time);

            //if rising sign is Gemini or Leo, then event is occuring
            if (risingSign == ZodiacName.Gemini || risingSign == ZodiacName.Leo)
            {
                return CalculatorResult.IsOccuring();
            }
            else
            {
                //if different sign, not occuring
                return CalculatorResult.NotOccuring();
            }

        }

        #endregion

        #region BUYING AND SELLING

        [EventCalculator(EventName.GoodSellingForProfit)]
        public static CalculatorResult IsGoodSellingForProfitOccuring(Time time, Person person)
        {
            //Selling for Profit. - Let the Moon and Mercury be free from the
            // conjunction or aspect of Mars. The Moon's situation in Taurus. Cancer
            // or Pisces would greatly help the seller. Try to keep Mercury in a kendra
            // from Lagna or at least in good aspect to Jupiter. Tuesday should be
            // avoided. Monday, Wednesday and Thursday are the best. While Friday
            // is unpropitious, Saturday is middling.


            //1.Let the Moon and Mercury be free from the conjunction or aspect of Mars

            //if moon aspected by mars, end here as not occuring
            var moonAspectedByMars = AstronomicalCalculator.IsPlanetAspectedByPlanet(PlanetName.Moon, PlanetName.Mars, time);
            if (moonAspectedByMars) { return CalculatorResult.NotOccuring(); }

            //if mercury aspected by mars, end here as not occuring
            var mercuryAspectedByMars = AstronomicalCalculator.IsPlanetAspectedByPlanet(PlanetName.Mercury, PlanetName.Mars, time);
            if (mercuryAspectedByMars) { return CalculatorResult.NotOccuring(); }

            //if moon conjunct with mars, end here as not occuring
            var moonConjunctWithMars = AstronomicalCalculator.IsPlanetConjunctWithPlanet(PlanetName.Moon, PlanetName.Mars, time);
            if (moonConjunctWithMars) { return CalculatorResult.NotOccuring(); }

            //if mercury conjunct with mars, end here as not occuring
            var mercuryConjunctWithMars = AstronomicalCalculator.IsPlanetConjunctWithPlanet(PlanetName.Mercury, PlanetName.Mars, time);
            if (mercuryConjunctWithMars) { return CalculatorResult.NotOccuring(); }


            //2. The Moon's situation in Taurus. Cancer or Pisces would greatly help the seller.

            //get sign moon is in 
            var moonSign = AstronomicalCalculator.GetPlanetRasiSign(PlanetName.Moon, time);

            //check if moon is in the correct sign
            var inCorrectSign = moonSign.GetSignName() == ZodiacName.Taurus ||
                                moonSign.GetSignName() == ZodiacName.Cancer ||
                                moonSign.GetSignName() == ZodiacName.Pisces;

            //if not correct sign, end here as not occuring
            if (inCorrectSign == false) { return CalculatorResult.NotOccuring(); }


            //3. Try to keep Mercury in a kendra from Lagna or at least in good aspect to Jupiter
            var mercuryInKendra = AstronomicalCalculator.IsPlanetInKendra(PlanetName.Mercury, time);
            var mercuryInGoodAspectToJupiter = AstronomicalCalculator.IsPlanetInGoodAspectToPlanet(PlanetName.Jupiter, PlanetName.Mercury, time);

            //if NOT in good aspect or in kendra, event not occuring
            if (!(mercuryInKendra || mercuryInGoodAspectToJupiter)) { return CalculatorResult.NotOccuring(); }


            //4. Tuesday should be avoided. Monday, Wednesday and Thursday are the best. While Friday
            // is unpropitious, Saturday is middling.

            //get weekday
            var weekDay = AstronomicalCalculator.GetDayOfWeek(time);

            //check if weekday correct 
            var inCorrectWeekday = weekDay == DayOfWeek.Monday ||
                                   weekDay == DayOfWeek.Wednesday ||
                                   weekDay == DayOfWeek.Thursday ||
                                   weekDay == DayOfWeek.Saturday;

            //if not correct weekday, end here as not occuring
            if (inCorrectWeekday == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();

        }

        [EventCalculator(EventName.GoodWeekdayForSelling)]
        public static CalculatorResult IsGoodWeekdayForSellingOccuring(Time time, Person person)
        {
            //Selling for Profit. -  Monday, Wednesday and Thursday are the best.


            //4. Monday, Wednesday and Thursday are the best.

            //get weekday
            var weekDay = AstronomicalCalculator.GetDayOfWeek(time);

            //check if weekday correct 
            var inCorrectWeekday = weekDay == DayOfWeek.Monday ||
                                   weekDay == DayOfWeek.Wednesday ||
                                   weekDay == DayOfWeek.Thursday;

            //if not correct weekday, end here as not occuring
            if (inCorrectWeekday == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();

        }

        [EventCalculator(EventName.GoodMoonSignForSelling)]
        public static CalculatorResult IsGoodMoonSignForSellingOccuring(Time time, Person person)
        {
            //Selling for Profit. - The Moon's situation in Taurus. Cancer
            // or Pisces would greatly help the seller.


            //2. The Moon's situation in Taurus. Cancer or Pisces would greatly help the seller.

            //get sign moon is in 
            var moonSign = AstronomicalCalculator.GetPlanetRasiSign(PlanetName.Moon, time);

            //check if moon is in the correct sign
            var inCorrectSign = moonSign.GetSignName() == ZodiacName.Taurus ||
                                moonSign.GetSignName() == ZodiacName.Cancer ||
                                moonSign.GetSignName() == ZodiacName.Pisces;

            //if not correct sign, end here as not occuring
            if (inCorrectSign == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();

        }

        [EventCalculator(EventName.BadForBuyingToolsUtensilsJewellery)]
        public static CalculatorResult IsBadForBuyingToolsUtensilsJewelleryOccuring(Time time, Person person)
        {
            //Buying Utensils, etc. - Place Jupiter in good aspect to the Moon while
            // buying brass vessels; to Mars when buying vessels of copper; to Saturn
            // if steel and iron; to ascendant if of silver. Avoid the asterisms of
            // Aslesha. Moola and Jyeshta. For buying tools, similarly avoid the 8th
            // and 9th lunar days and New Moon.

            //Buying Jewellery. -As usual unfavourable lunar days and asterisms should be avoided.

            //NOTE : Only bad constellaion & lunar days are used here


            //1.Avoid the asterisms of Aslesha. Moola and Jyeshta.
            //get ruling constellation
            var rulingConstellationName = AstronomicalCalculator.GetMoonConstellation(time).GetConstellationName();

            //check ruling constellation name
            var rightConstellation = rulingConstellationName == ConstellationName.Aslesha ||
                                     rulingConstellationName == ConstellationName.Moola ||
                                     rulingConstellationName == ConstellationName.Jyesta;


            //if not correct constellation, end here as not occuring
            if (rightConstellation == false) { return CalculatorResult.NotOccuring(); }



            //2. avoid the 8th and 9th lunar days and New Moon.
            //get lunar day
            var lunarDayNumber = AstronomicalCalculator.GetLunarDay(time).GetLunarDayNumber();

            //right lunar days to look for
            var rightLunarDay = lunarDayNumber == 8 ||
                                lunarDayNumber == 9 ||
                                lunarDayNumber == 1;

            //if not correct lunar days, end here as not occuring
            if (rightLunarDay == false) { return CalculatorResult.NotOccuring(); }

            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.GoodForBuyingBrassVessels)]
        public static CalculatorResult IsGoodForBuyingBrassVesselsOccuring(Time time, Person person)
        {
            //Buying Utensils, etc. - Place Jupiter in good aspect to the Moon while
            // buying brass vessels;
            // Avoid the asterisms of
            // Aslesha. Moola and Jyeshta. For buying tools, similarly avoid the 8th
            // and 9th lunar days and New Moon.

            //1
            //bad tithi & constellation for buying not occuring
            var badYoga = IsBadForBuyingToolsUtensilsJewelleryOccuring(time, person).Occuring;

            //if occuring end here, as not occuring
            if (badYoga) { return CalculatorResult.NotOccuring(); }


            //2. Place Jupiter in good aspect to the Moon while buying brass vessels
            //check aspect
            var goodAspect = AstronomicalCalculator.IsPlanetInGoodAspectToPlanet(PlanetName.Moon, PlanetName.Jupiter, time);

            //if NOT occuring end here, as not occuring
            if (goodAspect == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.GoodForBuyingCopperVessels)]
        public static CalculatorResult IsGoodForBuyingCopperVesselsOccuring(Time time, Person person)
        {
            //Buying Utensils, etc. -
            //Place Jupiter in good aspect to Mars when buying vessels of copper;
            //Avoid the asterisms of
            // Aslesha. Moola and Jyeshta. For buying tools, similarly avoid the 8th
            // and 9th lunar days and New Moon.

            //1
            //bad tithi & constellation for buying not occuring
            var badYoga = IsBadForBuyingToolsUtensilsJewelleryOccuring(time, person).Occuring;

            //if occuring end here, as not occuring
            if (badYoga) { return CalculatorResult.NotOccuring(); }


            //2. Place Jupiter in good aspect to Mars when buying vessels of copper;
            //check aspect
            var goodAspect = AstronomicalCalculator.IsPlanetInGoodAspectToPlanet(PlanetName.Mars, PlanetName.Jupiter, time);

            //if NOT occuring end here, as not occuring
            if (goodAspect == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.GoodForBuyingSteelIronVessels)]
        public static CalculatorResult IsGoodForBuyingSteelIronVesselsOccuring(Time time, Person person)
        {
            //Buying Utensils, etc. -
            //Place Jupiter in good aspect to Saturn if steel and iron.
            // Avoid the asterisms of
            // Aslesha. Moola and Jyeshta. For buying tools, similarly avoid the 8th
            // and 9th lunar days and New Moon.

            //1
            //bad tithi & constellation for buying not occuring
            var badYoga = IsBadForBuyingToolsUtensilsJewelleryOccuring(time, person).Occuring;

            //if occuring end here, as not occuring
            if (badYoga) { return CalculatorResult.NotOccuring(); }


            //2. Place Jupiter in good aspect to Saturn when buying vessels of copper;
            //check aspect
            var goodAspect = AstronomicalCalculator.IsPlanetInGoodAspectToPlanet(PlanetName.Saturn, PlanetName.Jupiter, time);

            //if NOT occuring end here, as not occuring
            if (goodAspect == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.GoodForBuyingSilverVessels)]
        public static CalculatorResult IsGoodForBuyingSilverVesselsOccuring(Time time, Person person)
        {
            //Buying Utensils, etc. -
            //Place Jupiter in good aspect to ascendant if of silver.
            //Avoid the asterisms of
            //Aslesha. Moola and Jyeshta. For buying tools, similarly avoid the 8th
            // and 9th lunar days and New Moon.

            //1
            //bad tithi & constellation for buying not occuring
            var badYoga = IsBadForBuyingToolsUtensilsJewelleryOccuring(time, person).Occuring;

            //if occuring end here, as not occuring
            if (badYoga) { return CalculatorResult.NotOccuring(); }


            //2. Place Jupiter in good aspect to ascendant if of silver;
            //check aspect
            var goodAspect = AstronomicalCalculator.IsPlanetInGoodAspectToHouse(HouseName.House1, PlanetName.Jupiter, time);

            //if NOT occuring end here, as not occuring
            if (goodAspect == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();
        }

        [EventCalculator(EventName.GoodForBuyingJewellery)]
        public static CalculatorResult IsGoodForBuyingJewelleryOccuring(Time time, Person person)
        {
            //Buying Jewellery. - The Sun and the Moon should be well situated and
            // aspected. As usual unfavourable lunar days and asterisms should be
            // avoided.

            //1
            //bad tithi & constellation for buying not occuring
            var badYoga = IsBadForBuyingToolsUtensilsJewelleryOccuring(time, person).Occuring;

            //if occuring end here, as not occuring
            if (badYoga) { return CalculatorResult.NotOccuring(); }


            //2. The Sun and the Moon should be well situated and aspected.
            //check aspect
            var isGood = SunAndMoonWellSituatedAndAspected();

            //if NOT occuring end here, as not occuring
            if (isGood == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();


            //returns true if well
            //NOTE : This method is experimental using smaller parts of shadbala calculators
            //TODO Testing needed
            bool SunAndMoonWellSituatedAndAspected()
            {
                //1. good aspect
                //the goodness of the aspect received by Sun & Moon is 
                //based on Drik Bala calculations (aspect strenght)
                var sunAspectStrength = AstronomicalCalculator.GetPlanetDrikBala(PlanetName.Sun, time);
                var moonAspectStrength = AstronomicalCalculator.GetPlanetDrikBala(PlanetName.Sun, time);

                //Note: positive bala = positive aspect, negative bala = negative aspect
                //if NOT postive number, end here as not good
                if (!(sunAspectStrength.ToDouble() > 0 && moonAspectStrength.ToDouble() > 0)) { return false; }


                //2. well situated
                //based on Planet Sthana Bala (Positonal strength)
                var sunPositionStrenght = AstronomicalCalculator.GetPlanetSthanaBala(PlanetName.Sun, time);
                var moonPositionStrenght = AstronomicalCalculator.GetPlanetSthanaBala(PlanetName.Moon, time);

                //Note: To determine if sthana bala is indicating good position or bad position
                //a neutral point is set, anything above is good & below is bad
                var sunNeutralPoint = AstronomicalCalculator.GetPlanetSthanaBalaNeutralPoint(PlanetName.Sun);
                var moonNeutralPoint = AstronomicalCalculator.GetPlanetSthanaBalaNeutralPoint(PlanetName.Moon);

                //if NOT above neutral number, end here as not good
                if (!(sunPositionStrenght.ToDouble() > sunNeutralPoint && moonPositionStrenght.ToDouble() > moonNeutralPoint)) { return false; }



                //if control reaches here then good aspectect & well situated
                return true;
            }

        }


        #endregion

        #region ASTRONOMICAL

        [EventCalculator(EventName.SunIsStrong)]
        public static CalculatorResult IsSunIsStrongOccuring(Time time, Person person)
        {
            var strongestPlanet = AstronomicalCalculator.GetAllPlanetOrderedByStrength(time)[0];
            var occuring = strongestPlanet == PlanetName.Sun;


            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.MoonIsStrong)]
        public static CalculatorResult IsMoonIsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllPlanetOrderedByStrength(time)[0] == PlanetName.Moon;

            //STRENGTH CALCULATION



            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.MarsIsStrong)]
        public static CalculatorResult IsMarsIsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllPlanetOrderedByStrength(time)[0] == PlanetName.Mars;


            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.MercuryIsStrong)]
        public static CalculatorResult IsMercuryIsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllPlanetOrderedByStrength(time)[0] == PlanetName.Mercury;


            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.JupiterIsStrong)]
        public static CalculatorResult IsJupiterIsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllPlanetOrderedByStrength(time)[0] == PlanetName.Jupiter;

            //STRENGTH CALCULATION



            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.VenusIsStrong)]
        public static CalculatorResult IsVenusIsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllPlanetOrderedByStrength(time)[0] == PlanetName.Venus;


            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.SaturnIsStrong)]
        public static CalculatorResult IsSaturnIsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllPlanetOrderedByStrength(time)[0] == PlanetName.Saturn;



            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.House1IsStrong)]
        public static CalculatorResult IsHouse1IsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllHousesOrderedByStrength(time)[0] == HouseName.House1;

            //STRENGTH CALCULATION



            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.House2IsStrong)]
        public static CalculatorResult IsHouse2IsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllHousesOrderedByStrength(time)[0] == HouseName.House2;



            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.House3IsStrong)]
        public static CalculatorResult IsHouse3IsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllHousesOrderedByStrength(time)[0] == HouseName.House3;



            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.House4IsStrong)]
        public static CalculatorResult IsHouse4IsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllHousesOrderedByStrength(time)[0] == HouseName.House4;




            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.House5IsStrong)]
        public static CalculatorResult IsHouse5IsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllHousesOrderedByStrength(time)[0] == HouseName.House5;



            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.House6IsStrong)]
        public static CalculatorResult IsHouse6IsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllHousesOrderedByStrength(time)[0] == HouseName.House6;



            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.House7IsStrong)]
        public static CalculatorResult IsHouse7IsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllHousesOrderedByStrength(time)[0] == HouseName.House7;



            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.House8IsStrong)]
        public static CalculatorResult IsHouse8IsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllHousesOrderedByStrength(time)[0] == HouseName.House8;



            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.House9IsStrong)]
        public static CalculatorResult IsHouse9IsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllHousesOrderedByStrength(time)[0] == HouseName.House9;



            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.House10IsStrong)]
        public static CalculatorResult IsHouse10IsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllHousesOrderedByStrength(time)[0] == HouseName.House10;



            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.House11IsStrong)]
        public static CalculatorResult IsHouse11IsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllHousesOrderedByStrength(time)[0] == HouseName.House11;



            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.House12IsStrong)]
        public static CalculatorResult IsHouse12IsStrongOccuring(Time time, Person person)
        {
            var occuring = AstronomicalCalculator.GetAllHousesOrderedByStrength(time)[0] == HouseName.House12;



            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.Sunrise)]
        public static CalculatorResult IsSunriseOccuring(Time time, Person person)
        {
            //actual sunrise at location, when center of sun disk is at horizon

            //get sunrise time for that day
            var sunriseTime = AstronomicalCalculator.GetSunriseTime(time);

            //+-5 min added to get the event, otherwise match with exact time might miss
            var MIN_5 = 0.08333333;// in hours
            var _5minAfter = sunriseTime.AddHours(MIN_5);
            var _5minBefore = sunriseTime.SubtractHours(MIN_5);

            var isAfter = time.GetLmtDateTimeOffset() >= _5minBefore.GetLmtDateTimeOffset();//after -5min
            var isBefore = time.GetLmtDateTimeOffset() <= _5minAfter.GetLmtDateTimeOffset();//before +5min

            //time is within +-5min
            var occuring = isAfter && isBefore;



            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.Sunset)]
        public static CalculatorResult IsSunsetOccuring(Time time, Person person)
        {
            //actual sunset at location, when center of sun disk is at horizon

            //get sunset time for that day
            var sunsetTime = AstronomicalCalculator.GetSunsetTime(time);

            //+-5 min added to get the event, otherwise match with exact time might miss
            var MIN_5 = 0.08333333;// in hours
            var _5minAfter = sunsetTime.AddHours(MIN_5);
            var _5minBefore = sunsetTime.SubtractHours(MIN_5);

            var isAfter = time.GetLmtDateTimeOffset() >= _5minBefore.GetLmtDateTimeOffset();//after -5min
            var isBefore = time.GetLmtDateTimeOffset() <= _5minAfter.GetLmtDateTimeOffset();//before +5min

            //time is within +-5min
            var occuring = isAfter && isBefore;



            return new() { Occuring = occuring };
        }

        [EventCalculator(EventName.Midday)]
        public static CalculatorResult IsMiddayOccuring(Time time, Person person)
        {
            //This is marked when the centre of the Sun is exactly on the
            // meridian of the place. The apparent noon is
            // almost the same for all places.


            //get apparent time
            var localApparentTime = AstronomicalCalculator.GetLocalApparentTime(time);
            var apparentNoon = AstronomicalCalculator.GetNoonTime(time);

            //+-5 min added to get the event, otherwise match with exact time might miss
            var MIN_5 = 0.08333333;// in hours
            var _5minAfter = apparentNoon.AddHours(MIN_5);
            var _5minBefore = apparentNoon.AddHours(-MIN_5);

            var isAfter = localApparentTime >= _5minBefore;//after -5min
            var isBefore = localApparentTime <= _5minAfter;//before +5min

            //time is within 11:55AM to 12:05PM
            var occuring = isAfter && isBefore;



            return new() { Occuring = occuring };
        }


        #endregion
        
        #region BUILDING CONSTRUCTION

        [EventCalculator(EventName.BadLunarMonthForBuilding)]
        public static CalculatorResult BadLunarMonthForBuilding(Time time, Person person)
        {
            //No house-building should be commenced in the lunar months of
            // Jyeshta, Ashadha, Bhadrapada, Aswayuja, Margasira, Pushya and
            // Phalguna as they connote respectively death, destruction, disease,
            // quarrels and misunderstandings, loss of wealth, incendiarism and
            // physical danger

            //get lunar current lunar month
            var lunarMonth = AstronomicalCalculator.GetLunarMonth(time);

            if (lunarMonth is LunarMonth.Jaistam or LunarMonth.Ashadam or LunarMonth.Bhadrapadam
                or LunarMonth.Aswijam or LunarMonth.Margasiram or LunarMonth.Pooshiam or LunarMonth.Phalgunam)
            {
                return CalculatorResult.IsOccuring();
            }

            //if conrtol reaches here then event is ocuring
            return CalculatorResult.NotOccuring();
        }


        // The lunar months of Chaitra, Vaisakha, Sravana,
        // Kartika and Magha are the best.


        [EventCalculator(EventName.GoodSunSignForBuilding)]
        public static CalculatorResult GoodSunSignForBuilding(Time time, Person person)
        {
            // The Sun should occupy fixed signs or
            // at least movable signs but

            //get sign sun is in
            var sunSign = AstronomicalCalculator.GetSunSign(time).GetSignName();

            //check if sign is a fixed or movable sign
            var isFixedSign = AstronomicalCalculator.IsFixedSign(sunSign);
            var isMovableSign = AstronomicalCalculator.IsMovableSign(sunSign);
            var occuring = isFixedSign || isMovableSign;

            //if conrtol reaches here then event is ocuring
            return new CalculatorResult() { Occuring = occuring };
        }

        [EventCalculator(EventName.BadSunSignForBuilding)]
        public static CalculatorResult BadSunSignForBuilding(Time time, Person person)
        {
            // no building work should be undertaken when
            // the Sun is in common signs.

            //get sign sun is in
            var sunSign = AstronomicalCalculator.GetSunSign(time).GetSignName();

            //check if sign is a common sign
            var isCommonSign = AstronomicalCalculator.IsCommonSign(sunSign);
            var occuring = isCommonSign;

            //if conrtol reaches here then event is ocuring
            return new CalculatorResult() { Occuring = occuring };
        }

        [EventCalculator(EventName.GoodLunarDayForBuilding)]
        public static CalculatorResult GoodLunarDayForBuilding(Time time, Person person)
        {
            //All odd tithis (lunar days) except the 9th are good.
            //odd numbers : 1, 3, 5, 7, 11, 13, 15

            //Of the even tithis the 2nd, 6th and 10th are auspicious.
            //even numbers : 2, 6, 10,

            //get lunar day
            var lunarDayNumber = AstronomicalCalculator.GetLunarDay(time).GetLunarDayNumber();

            //right lunar days to look for
            var rightLunarDay = lunarDayNumber == 1 ||
                                lunarDayNumber == 3 ||
                                lunarDayNumber == 5 ||
                                lunarDayNumber == 7 ||
                                lunarDayNumber == 11 ||
                                lunarDayNumber == 13 ||
                                lunarDayNumber == 15 ||//full moon
                                lunarDayNumber == 2 ||
                                lunarDayNumber == 6 ||
                                lunarDayNumber == 10;

            //if not correct lunar days, end here as not occuring
            if (rightLunarDay == false) { return CalculatorResult.NotOccuring(); }


            //if control reaches here then event is ocuring
            return CalculatorResult.IsOccuring();

        }

        [EventCalculator(EventName.GoodWeekDayForBuilding)]
        public static CalculatorResult GoodWeekDayForBuilding(Time time, Person person)
        {
            // Monday, Wednesday, Thursday and  Friday are the best,
            // Monday, Wednesday and Thursday are the best.

            //get week day
            var weekday = AstronomicalCalculator.GetDayOfWeek(time);


            switch (weekday)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    return CalculatorResult.IsOccuring();
                default:
                    //event not occuring, if planet not same
                    return CalculatorResult.NotOccuring();
            }

        }

        [EventCalculator(EventName.BadLunarPhaseForBuilding)]
        public static CalculatorResult BadLunarPhaseForBuilding(Time time, Person person)
        {
            // Even Monday should be rejected when the Moon is
            // waning.
            //Waning moon is bad

            //get the moon phase
            var moonPhase = AstronomicalCalculator.GetLunarDay(time).GetMoonPhase();

            //occuring when moon is wanning
            var occuring = moonPhase == MoonPhase.DarkHalf;

            return new CalculatorResult() { Occuring = occuring };
        }

        [EventCalculator(EventName.BadWeekDayForBuilding)]
        public static CalculatorResult BadWeekDayForBuilding(Time time, Person person)
        {
            //Saturday should be rejected as it connots frequent thefts. Sunday
            // should also be avoided unless the day is otherwise very auspicious.

            //get week day
            var weekday = AstronomicalCalculator.GetDayOfWeek(time);


            switch (weekday)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return CalculatorResult.IsOccuring();
                default:
                    //event not occuring, if planet not same
                    return CalculatorResult.NotOccuring();
            }

        }

        [EventCalculator(EventName.BadWeekDayForRepairs)]
        public static CalculatorResult BadWeekDayForRepairs(Time time, Person person)
        {
            // Do not commence repairs on Tuesdays.

            //get week day
            var weekday = AstronomicalCalculator.GetDayOfWeek(time);


            switch (weekday)
            {
                case DayOfWeek.Tuesday:
                    return CalculatorResult.IsOccuring();
                default:
                    //event not occuring, if planet not same
                    return CalculatorResult.NotOccuring();
            }

        }


        [EventCalculator(EventName.GoodYogaForRepairs)]
        public static CalculatorResult GoodYogaForRepairs(Time time, Person person)
        {

            // Friday at a moment when Lagna is Taurus or Libra and
            // Monday when Cancer is rising are very suitable for beginning repairs.

            //friday & lagna is taurus or libra
            var isFriday = AstronomicalCalculator.GetDayOfWeek(time) == DayOfWeek.Friday;
            var lagnaIsTaurus = AstronomicalCalculator.GetHouseSignName(1, time) == ZodiacName.Taurus;
            var lagnaIsLibra = AstronomicalCalculator.GetHouseSignName(1, time) == ZodiacName.Libra;
            var isFridayLagnaTaurusLibra = isFriday && (lagnaIsLibra || lagnaIsTaurus);

            //monday & lagna is cancer
            var isMonday = AstronomicalCalculator.GetDayOfWeek(time) == DayOfWeek.Monday;
            var lagnaIsCancer = AstronomicalCalculator.GetHouseSignName(1, time) == ZodiacName.Cancer;
            var isMondayLagnaCancer = isMonday && lagnaIsCancer;

            //if either is true
            var occuring = isFridayLagnaTaurusLibra || isMondayLagnaCancer;

            return new CalculatorResult() { Occuring = occuring };

        }


        [EventCalculator(EventName.GoodYogaForRepairs2)]
        public static CalculatorResult GoodYogaForRepairs2(Time time, Person person)
        {

            // The Lagna must be occupied by a benefic and the Moon should be in an aquatic sign.

            //benefic in lagna
            var beneficsInLagna = AstronomicalCalculator.IsBeneficPlanetInHouse(1, time);

            //monday in aquatic sign
            var moonSign = AstronomicalCalculator.GetMoonSignName(time);
            var isMoonInAquaticSign = AstronomicalCalculator.IsAquaticSign(moonSign);

            //if either is true
            var occuring = isMoonInAquaticSign || beneficsInLagna;

            return new CalculatorResult() { Occuring = occuring };

        }

        //[EventCalculator(EventName.BadConstellationForRepairs)]
        //public static Prediction BadConstellationForRepairs(Time time, Person person)
        //{

        //    //No repairs should be started under the constellations of Krittika, Makha.
        //    // Pushyami, Pubba, Hasta, Moola and Revati when Mars is transiting
        //    // these constellations.



        //    var occuring = isMoonInAquaticSign || beneficsInLagna;

        //    return new Prediction() { Occuring = occuring };

        //}


        #endregion

    }

}

//--------------ARCHIVED CODE-----------------
//bool IsLagnaLordInLagnaOccuring(Time time)
//{
////lagna lord is in same sign as first house

////get lord of lagna (house 1)
//PlanetName lordOfLagna = AstronomicalCalculator.GetLordOfHouse(HouseName.House1, time);

////get house 1 sign
//var house1Sign = AstronomicalCalculator.GetHouseSignName(1, time);

////get sign lagna lord is in
//var signLagnaLordIsIn = AstronomicalCalculator.GetPlanetRasiSign(lordOfLagna, time);

//    //if the house 1 sign & lagna lord sign is same
//    if (house1Sign == signLagnaLordIsIn.GetSignName())
//{
//    //event is occuring
//    return Prediction.IsOccuring();
//}
//else
//{
//    return Prediction.NotOccuring();
//}
//}
//bool Is7thLordIn7thOccuring(Time time)
// {
// //7t lord is in same sign as 7th house
// 
// //get lord of 7th 
// PlanetName lordOf7th = AstronomicalCalculator.GetLordOfHouse(HouseName.House7, time);
// 
// //get house 7 sign
// var house7Sign = AstronomicalCalculator.GetHouseSignName(7, time);
// 
// //get sign 7th lord is in
// var sign7thLordIsIn = AstronomicalCalculator.GetPlanetRasiSign(lordOf7th, time);
// 
// //if the house 7 sign & 7th lord sign is same
// if (house7Sign == sign7thLordIsIn.GetSignName())
// {
// //event is occuring
// return Prediction.IsOccuring();
// }
// else
// {
// return Prediction.NotOccuring();
// }
// }
// 