using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ENtityFrameWork_Test.Models
{
    public class Result<T>
    {
        #region Properties

        /// <summary>
        /// </summary>
        public T Data { get; set; }


        public bool Status { get; set; }


        /// <summary>
        /// </summary>
       public string Messages { get; set; }
        #endregion

        #region Constructors

        private Result()

        {
        }


        /// <summary>
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="ResultError"></param>
        /// <param name="data"></param>

        public Result(bool status, string messages, T data)
        {
            Status = status;
            Messages = messages;
            Data = data;
        }

        #endregion
    }
}
