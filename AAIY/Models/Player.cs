using System;

namespace AAIY.Models
{
    class Player
    {
        //stats
        public int str { get; set; }
        public int agi { get; set; }
        public int con { get; set; }
        public int ntl { get; set; }
        public int cha { get; set; }
        public int luk { get; set; }

        //specs
        public int level { get; set; }
        public int hpCurr { get; set; }
        public int hpMax { get; set; }
        public int exp { get; set; }
        public int statPoints { get; set; }
        public string name { get; set; }


        public Player()
        {
            str = 1;
            agi = 1;
            con = 1;
            ntl = 1;
            cha = 1;
            luk = 1;
            level = 1;
            hpMax = 11;
            hpCurr = hpMax;
            exp = 0;
        }

        public void AddExp(int amnt)
        {
            exp += amnt; //base gained amount
            exp += (int)(amnt * (ntl/20)); //bonus amount
            if(exp >= (level * 100)) { LevelUp(); } //check for level up
        }

        public void LevelUp()
        {
            exp = exp - (level * 100);
            level++;
            hpMax += 10; //base hp gain
            hpMax += con; //bonus hp gain
        }

        public void Die()
        {
            exp -= (level * 10); //exp loss
            if (exp < 0) { exp = 0; } //ensure exp doesn't go negative
            hpCurr = hpMax; //reset health
            if(new Random().Next(100) > 95) //check for loss stat possibility
            {
                var down = new Random().Next(60);  //roll for loss stat actuality
                if(down == 10) { str = str == 1 ? str : str--; }
                if(down == 20) { agi = agi == 1 ? agi : agi--; }
                if(down == 30) { con = con == 1 ? con : con--; }
                if(down == 40) { ntl = ntl == 1 ? ntl : ntl--; }
                if(down == 50) { cha = cha == 1 ? cha : cha--; }
                if(down == 60) { luk = luk == 1 ? luk : luk--; }
            }
        }
    }
}
