using NoName.StateMachine;
using System.Collections.Generic;
using UnityEngine;

namespace NoName.Saving
{
    public class SavePromoter
    {
        const string SAVE_KEY = "example_save_key";
        const string LAST_SLOT_KEY = "example_last_slot_key";

        const char DATA_SPLIT_CHAR = '|';
        const char ID_SPLIT_CHAR = '~';

        public int LastSlotSaved { get; private set; }


        public SavePromoter()
        {
            LastSlotSaved = PlayerPrefs.GetInt(LAST_SLOT_KEY, 0);
        }
    
        public void Save(State state, IList<ISaveable> saveables, int slot)
        {
            if (saveables == null) return;

            string save = "";

            int i = 0;
            foreach (var item in saveables)
            {
                save += item.Identificator;
                save += ID_SPLIT_CHAR;
                save += item.OnSave();

                if (i < saveables.Count - 1)
                {
                    save += DATA_SPLIT_CHAR;
                }

                i++;
            }

            LastSlotSaved = slot;
            PlayerPrefs.SetInt(LAST_SLOT_KEY, LastSlotSaved);

            PlayerPrefs.SetString(GetSaveKey(state, slot), save);
            PlayerPrefs.Save();
        }

        public Dictionary<State, Dictionary<string, string>> Load(int slot)
        {
            Dictionary<State, Dictionary<string, string>> map = new Dictionary<State, Dictionary<string, string>>();

            foreach (var @enum in System.Enum.GetValues(typeof(State)))
            {
                var state = (State)@enum;
                var load = PlayerPrefs.GetString(GetSaveKey(state, slot), "");

                if (string.IsNullOrEmpty(load))
                {
                    continue;
                }

                map.Add(state, new Dictionary<string, string>());

                string[] pairs = load.Split(DATA_SPLIT_CHAR);

                foreach (var pair in pairs)
                {
                    try
                    {
                        string[] idValue = pair.Split(ID_SPLIT_CHAR);
                        map[state].Add(idValue[0], idValue[1]);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            return map;
        }

        public bool IsSlotEmpty(int slot)
        {
            foreach (var @enum in System.Enum.GetValues(typeof(State)))
            {
                var state = (State)@enum;
                var load = PlayerPrefs.GetString(GetSaveKey(state, slot), "");

                if (!string.IsNullOrEmpty(load)) return false;
            }

            return true;
        }

        private string GetSaveKey(State state, int slot)
        {
            return SAVE_KEY + $"_{state}" + $"_{slot}";
        }
    }
}