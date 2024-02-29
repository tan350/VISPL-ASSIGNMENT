using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace FHP.RES
{
    public class Education_Level
    {

        public enum EducationLevel
        {
            [Description("10th Grade")]
            Tenth,
            [Description("12th Grade")]
            Twelveth,
            [Description("Bachelor of Technology")]
            Btech,
            [Description("Master of Technology")]
            Mtech,
            [Description("Bachelor of Computer Applications")]
            BCA,
            [Description("Master of Computer Applications")]
            MCA,
            [Description("Bachelor of Science")]
            BSc,
            [Description("Master of Science")]
            MSc,
            [Description("Bachelor of Arts")]
            BA,
            [Description("Master of Arts")]
            MA,
            [Description("Doctor of Philosophy")]
            PhD,
            [Description("Bachelor of Commerce")]
            BCom,
            [Description("Master of Commerce")]
            MCom,
            [Description("Bachelor of Business Administration")]
            BBA,
            [Description("Master of Business Administration")]
            MBA,
            [Description("Bachelor of Engineering")]
            BE,
            [Description("Master of Engineering")]
            ME,
            [Description("Bachelor of Medicine, Bachelor of Surgery")]
            MBBS,
            [Description("Bachelor of Dental Surgery")]
            BDS,
            [Description("Doctor of Medicine")]
            MD,
            [Description("Doctor of Dental Medicine")]
            DDM,
            [Description("Bachelor of Pharmacy")]
            BPharm,
            [Description("Master of Pharmacy")]
            MPharm,
            [Description("Bachelor of Arts in Education")]
            BAEd,
            [Description("Master of Arts in Education")]
            MAEd,
            [Description("Bachelor of Laws")]
            LLB,
            [Description("Master of Laws")]
            LLM,
            [Description("Bachelor of Fine Arts")]
            BFA,
            [Description("Master of Fine Arts")]
            MFA,
            [Description("Bachelor of Architecture")]
            BArch,
            [Description("Master of Architecture")]
            MArch,
            [Description("Bachelor of Design")]
            BDes,
            [Description("Master of Design")]
            MDes,
            [Description("Bachelor of Journalism")]
            BJ,
            [Description("Master of Journalism")]
            MJ,
            [Description("Bachelor of Social Work")]
            BSW,
            [Description("Master of Social Work")]
            MSW,
            [Description("Bachelor of Physiotherapy")]
            BPT,
            [Description("Master of Physiotherapy")]
            MPT,
            [Description("Bachelor of Occupational Therapy")]
            BOT,
            [Description("Master of Occupational Therapy")]
            MOT,
            [Description("Bachelor of Science in Nursing")]
            BSN,
            [Description("Master of Science in Nursing")]
            MSN,
            [Description("Bachelor of Hotel Management")]
            BHM,
            [Description("Master of Hotel Management")]
            MHM,
            [Description("Bachelor of Ayurvedic Medicine and Surgery")]
            BAMS,
            [Description("Master of Ayurvedic Medicine and Surgery")]
            MAMS
        }

        public enum UserRole
        {
            SuperAdmin,
            Admin,
            Guest,
            Self
        }

        public static string GetEnumValueAtIndex<TEnum>(byte index) where TEnum : Enum
        {
            TEnum[] enumValues = (TEnum[])Enum.GetValues(typeof(TEnum));

            if (index < 0 || index >= enumValues.Length)
            {
                return "";
            }
            return enumValues[index].ToString();
        }

        public static string GetEducationDescriptionAtIndex(byte index)
        {
            EducationLevel[] enumValues = (EducationLevel[])Enum.GetValues(typeof(EducationLevel));

            if (index < 0 || index >= enumValues.Length)
            {
                return "";
            }

            EducationLevel enumValue = enumValues[index];
            var descriptionAttribute = (DescriptionAttribute[])enumValue.GetType().GetField(enumValue.ToString())
                                        .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttribute.Length > 0 ? descriptionAttribute[0].Description : enumValue.ToString();
        }

        public static string GetUserDescriptionAtIndex(byte index)
        {
            UserRole[] enumValues = (UserRole[])Enum.GetValues(typeof(UserRole));

            if (index < 0 || index >= enumValues.Length)
            {
                return "";
            }

            UserRole enumValue = enumValues[index];
            var descriptionAttribute = (DescriptionAttribute[])enumValue.GetType().GetField(enumValue.ToString())
                                        .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttribute.Length > 0 ? descriptionAttribute[0].Description : enumValue.ToString();
        }


        public enum EditMode { Add, Edit, Lock }

        public enum ExceptionMessage
        {
            FileNotFound,
            WritingError,
            ReadingError,
            UpdatingError,
            InvalidInput,
            DatabaseError,
            // Add more error codes as needed
        }

        public static string GetErrorMessage(ExceptionMessage errorCode)
        {
            switch (errorCode)
            {
                case ExceptionMessage.FileNotFound:
                    return "File not found.";
                case ExceptionMessage.WritingError:
                    return "Error writing to file.";
                case ExceptionMessage.ReadingError:
                    return "Error reading from file.";
                case ExceptionMessage.UpdatingError:
                    return "Error in updating record in file.";
                case ExceptionMessage.InvalidInput:
                    return "Invalid input provided.";
                case ExceptionMessage.DatabaseError:
                    return "Database error occurred.";
                default:
                    return "An unexpected error occurred.";
            }
        }

        public enum Message
        {
            [Description("First Name Field cannot be Empty ")]
            FirstNameEmpty,

            [Description("Current Company Field cannot be Empty")]
            CurrentCompanyEmpty,

            [Description("DOJ Field cannot be Empty")]
            DOJEmpty,

            [Description("Qualification Field cannot be Empty")]
            QualificationEmpty,

            [Description("First Name cannot be more than 50 characters")]
            FirstNameTooLong,

            [Description("Last Name cannot be more than 50 characters")]
            LastNameTooLong,

            [Description("Middle Name cannot be more than 25 characters")]
            MiddleNameTooLong,

            [Description("Current Address cannot be more than 500 characters")]
            CurrentAddressTooLong,

            [Description("Current Company cannot be more than 255 characters")]
            CurrentCompanyTooLong,

            [Description("Cannot Delete as the User don't have permissions other than read only")]
            ReadOnlyUserCannotDelete,

            [Description("Record not found in the list.")]
            RecordMissing,

            [Description("Please select a row to delete.")]
            SelectRowToDelete,

            [Description("Record Deleted successfully.")]
            RecordDeleted,

            [Description("Do you want to Delete Row Data?")]
            WantToDeleteRow,

            [Description("Invalid line format.")]
            RecordInvalidFormat,

            [Description("Record Edited Successfully.")]
            RecordEdited,

            [Description("Do you want to clear the data?")]
            WantToClearData,

        }

        public byte GetValidationMessageAsByte(Message message)
        {
            return (byte)message;
        }

        public Message GetValidationMessageFromByte(byte byteValue)
        {
            return (Message)byteValue;
        }

        public string GetDescriptionString(Message message)
        {
            var enumType = typeof(Message);
            var memberInfo = enumType.GetMember(message.ToString());

            if (memberInfo.Length > 0)
            {
                var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(memberInfo[0], typeof(DescriptionAttribute));

                if (descriptionAttribute != null)
                {
                    return descriptionAttribute.Description;
                }
            }

            return "Unknown Validation Message Description";
        }

        public string GetDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo != null)
            {
                var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

                if (attribute != null)
                {
                    return attribute.Description;
                }
            }

            return value.ToString();
        }

        public string GetDescriptionStringFromByte(byte byteValue)
        {
            Education_Level.Message enumValue = (Education_Level.Message)byteValue;

            return GetDescriptionString(enumValue);
        }


    }

}
