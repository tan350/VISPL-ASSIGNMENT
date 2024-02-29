using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FHP.VO
{
    /// <summary>
    /// Represents a data structure for storing information about a record.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RecordVO
    {
        /// <summary>
        /// Serial number of the record.
        /// </summary>
        public long SrNo;

        /// <summary>
        /// Prefix of the person's name.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        public string Prefix;

        /// <summary>
        /// First name of the person.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string FirstName;

        /// <summary>
        /// Middle name of the person.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 25)]
        public string MiddleName;

        /// <summary>
        /// Last name of the person.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string LastName;

        /// <summary>
        /// Date of birth of the person.
        /// </summary>
        public DateTime DOB;

        /// <summary>
        /// Date of joining of the person.
        /// </summary>
        public DateTime DOJ;

        /// <summary>
        /// Qualification of the person.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string Qualification;

        /// <summary>
        /// Current address of the person.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string CurrentAddress;

        /// <summary>
        /// Current company of the person.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 400)]
        public string CurrentCompany;

        /// <summary>
        /// Date of joining the current company.
        /// </summary>
        

        /// <summary>
        /// Converts the structure to a byte array.
        /// </summary>
        /// <returns>A byte array representing the structure.</returns>
        public byte[] ToBytes()
        {
            int size = Marshal.SizeOf(this);
            byte[] arr = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(this, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        /// <summary>
        /// Converts a byte array to a RecordVO structure.
        /// </summary>
        /// <param name="arr">The byte array to convert.</param>
        /// <returns>A RecordVO structure.</returns>
        public static RecordVO FromBytes(byte[] arr)
        {
            RecordVO record = new RecordVO();
            int size = Marshal.SizeOf(record);

            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(arr, 0, ptr, size);
            record = (RecordVO)Marshal.PtrToStructure(ptr, record.GetType());
            Marshal.FreeHGlobal(ptr);
            return record;
        }
    }
}
