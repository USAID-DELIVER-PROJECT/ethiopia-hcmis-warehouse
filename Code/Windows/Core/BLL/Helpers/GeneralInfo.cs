using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using DAL;

namespace BLL
{
    /// <summary>
    /// Loads the general settings for this Hub
    /// This includes the Min Max and AMC months, the Hub name etc
    /// </summary>
    public class GeneralInfo : _GeneralInfo
    {
        private static GeneralInfo _current;
        /// <summary>
        /// Gets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public static GeneralInfo Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new GeneralInfo();
                    _current.LoadAll();
                }
                return _current;
            }
        }
        public string LogoUrl
        {
            get
            {
                if (IsColumnNull("Logo") || String.IsNullOrEmpty(Logo))
                {
                    Logo = "/HCMIS/Default.png";
                    Save();
                }
                string apppath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string path = apppath + Logo;
                return Path.GetFullPath(path);
            }
        }

        public void SaveImage(string path)
        {
            var filename = Path.GetFileName(path);
            var extension = Path.GetExtension(path);
            Image image = System.Drawing.Image.FromFile(path);
            Logo = "/HCMIS/" + filename;
            SaveImage(image);
        }
        public void SaveImage(Image image)
        {
            Image = ConvertImageToByteArray(image, image.RawFormat);
            Save();
        }
        public Image GetLogo()
        {
            if (IsColumnNull("Image"))
            {
                return null;
            }
            return System.Drawing.Image.FromStream(new MemoryStream(Image));
        }

        private byte[] ConvertImageToByteArray(Image imageToConvert,
                                       ImageFormat formatOfImage)
        {
            byte[] Ret;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imageToConvert.Save(ms, formatOfImage);
                    Ret = ms.ToArray();
                }
            }
            catch (Exception) { throw; }
            return Ret;
        }

        private int? _supplierID;
        public int SupplierID
        {
            get
            {
                if (_supplierID == null)
                {
                    var supplier = new Supplier();
                    supplier.LoadByRowGuid(this.FacilityGuid);
                    _supplierID = supplier.ID;
                }
                return _supplierID.Value;
            }
        }
        private int? _institutionID;
        public int InstitutionID
        {
            get
            {
                if (_institutionID == null)
                {
                    var institution = new Institution();
                    institution.LoadByRowGuid(this.FacilityGuid);
                    _institutionID = institution.ID;
                }
                return _institutionID.Value;
            }
        }

    }
}
