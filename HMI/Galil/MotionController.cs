using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galil
{
    class MotionController
    {
        private gclib gclib;
        private int rc;
        private string mAddress;
        private bool mConnected;
        
        public bool Connected
        {
            get { return mConnected; }
        }

        public MotionController(string address) {
            mAddress = address;
            mConnected = false;

            gclib = new gclib();
        }

        public void Open() {
            gclib.GOpen(mAddress);
            mConnected = true;
        }

        public void Close()
        {
            gclib.GClose();
        }
    }
}
