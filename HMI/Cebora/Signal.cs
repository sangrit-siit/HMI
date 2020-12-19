using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cebora
{
    class Signal<T>
    {
        private PowerSource mCebora;
        private Dictionary<string, T> mSignals = new Dictionary<string, T>();

        public T this[string key]
        {
            get { return mSignals[key]; }
            set { mSignals[key] = value; }
        }
    }
}
