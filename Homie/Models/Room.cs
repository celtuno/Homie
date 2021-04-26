using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homie.Models
{
    class Room: SqlCommunication
    {
        //static List<Sensor> sensors = new List<Sensor>();//
         static List<int> roomId = new List<int>();
        static List<int> houseId = new List<int>();
        //public static List<int> sensorId = new List<int>();
        static  List<string> roomName = new List<string>();
        
        public List<Tuple<int,int,string>> lists = new System.Collections.Generic.List<Tuple<int, int, string>>();
        //List<Tuple<string>> lists = new System.Collections.Generic.List<Tuple<string>>();
        Object[,] arraylist = new Object[roomId.Count, roomId.Count];//,roomId.Count];


        LoginUser loginUser = new LoginUser();

        public List<int> RoomId
        {
            get { return roomId; }
        }
        public List<int> HouseId
        {
            get { return houseId; }
        }
         public List<string> RoomNames
        {
            get {return roomName; }
        }
        
       
        public Room()
        {
            lists.Clear();
            
            for (int i = roomId.Count-1; i >= 0; i--)
            {
                
                
                lists.Add(new Tuple<int, int, string>(roomId[i], houseId[i], roomName[i]));
                //arraylist[i, i] = (test, houseId[i]);//, roomName[i]];

            }

        }
        
        public Room(bool reset)
        {
            if (reset)
            {
                roomId.Clear();
                houseId.Clear();
                roomName.Clear();
            }
        }
        
        public Room(int tmpRoomId, int tmpHouseId, string tmpRoomName )
        {

            roomName.Add(tmpRoomName);
            houseId.Add(tmpHouseId);
            roomId.Add(tmpRoomId);
            

        }
        public void GetRoom()
        {
            GetRooms("GetRooms", loginUser.UserHouse);
        }



    }
}
