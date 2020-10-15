using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ZeroUnpacker
{
    class ISO9660
    {
        /*
        ISO 9660 + UDF
        [Need to be modified]7086L long (LE) ISO size = value*0x800 + 0x800
        7886L long (LE) ISO size = value*0x800 + 0x800,repeat
        [Need to be modified] 8000L 01 43 44 30 30 31 01 00 .CD001. PLAYSTATIONS tart flag
        [Need to be modified] 8050L long (LE + BE 8 bytes in total) ISO size = value * 0x800
        809EL long (LE + BE 8 bytes in total) File LBA index area address index_offset = value * 0x800

        [Need to be modified] 110C0L  ISO size = value*0x800 + 0x83000
        [Need to be modified] 190C0L  ISO size = value*0x800 + 0x83000
        [Need to be modified] 20054L  ISO size = value*0x800 + 0x83000
        20078L long Number of files
        Seek(index_offset,0)//Path Tables
        {   
            Number of files
            {
                    ???
            }
            
        }



        */
        public static ArrayList LBAReader(string path)
        {
            ArrayList arrayListLBA = null;
            FileStream fs = null;
            fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            arrayListLBA = new ArrayList();
            //int blockSize = 0;
            //string str = "";
            Dictionary<int, string> dNumDir = new Dictionary<int, string>();
            
            arrayListLBA.Sort();
            return arrayListLBA;

        }
    }
}
