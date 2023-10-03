using TrickOrTreatRPG.ThingsToEncounter.Characters;

namespace TrickOrTreatRPG.Encounters;

public class ThingToEncounterFactory
{
        private Random _random = new Random();
        int houseCount;

        private bool _coachHouseBool = false;
        private bool _sweetOLHouseBool = false;
        private bool _bullyBool = false;
        private bool _munchkins = false;
        private bool _rpsFriend = false;
        
      
        public ThingToEncounter CreateRandomEncounter()
        {
            int randomInt = _random.Next(1, 101);
            
            if (randomInt <= 65 && houseCount >= 4) // returns a Character
            {
                int randomCharacter = _random.Next(1, 4);
                if (randomCharacter == 1 && _bullyBool == false)
                {
                    _bullyBool = true;
                    return new Bully();
                }
                if (randomCharacter == 2 && _munchkins == false)
                {
                    _munchkins = true;
                    return new Munchkins();
                }
                if (randomCharacter == 3 && _rpsFriend == false)
                {
                    _rpsFriend = true;
                    return new RockPaperScissorsFriend();
                }
            }
                
              else if (randomInt >= 66) // returns a House
            {
                houseCount++;
                int randomHouse = _random.Next(1, 4);
                if (randomHouse == 1 && _coachHouseBool == false)
                {
                    _coachHouseBool = true;
                    return new CoachHouse();
                }
                 if (randomHouse <= 2 && _sweetOLHouseBool == false)
                {
                    _sweetOLHouseBool = true;
                    return new SweetOldLadyHouse();
                }
            }
            return new GenericHouse();;
        }
}

