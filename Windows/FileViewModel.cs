using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESolutions.Youmoto.Windows
{
    public class FileViewModel
    {
        //Properties
        #region File
        public FileInfo File
        {
            get;
            set;
        }
        #endregion

        #region Status
        public String Status
        {
            get;
            set;
        } = String.Empty;
        #endregion

        #region CloudUrl
        public Uri CloudUrl
        {
            get;
            set;
        }
        #endregion

        //Constructors
        #region FileViewModel
        public FileViewModel(FileInfo file)
        {
            this.File = file;
        }
        #endregion
    }
}
