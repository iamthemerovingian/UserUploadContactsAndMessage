using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace UserUploadContactsAndMessage.Models
{
    public class File
    {
        public int FilePathId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        public int UserId { get; set; }
        public byte[] bytes { get; set; }

        public byte[] ToByteArray(HttpPostedFileBase upload)
        {
            bytes = new byte[upload.ContentLength];
            FileName = upload.FileName;
            using (var binaryReader = new BinaryReader(upload.InputStream))
            {
                bytes = binaryReader.ReadBytes(upload.ContentLength);
                Globals.ContactsData = bytes;
            }

            return bytes;
        }
    }
}