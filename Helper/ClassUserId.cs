using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomTarKuz.Helper
{
    class ClassUserId
    {
        private ClassUserId() { }
        private static readonly Lazy<ClassUserId> instance = new Lazy<ClassUserId>(() => new ClassUserId());
        public static ClassUserId Instance { get { return instance.Value; } }
        public int USER { get; set; }

    }
}
