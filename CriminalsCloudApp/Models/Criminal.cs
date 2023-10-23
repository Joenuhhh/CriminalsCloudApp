using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CriminalsCloudApp.Models
{
    public class Criminal
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Sex { get; set; }
        public string Hair { get; set; }
        public string Eyes { get; set; }
        public string Height { get; set; }
        public string Build { get; set; }
        public string Finger_Print { get; set; }
        public string Glasses { get; set; }

        public Criminal(int id, string name, string sex, string hair, string eyes, string height,
            string build, string fingerPrint, string glasses)
        {
            Id = id;
            Name = name;
            Sex = sex;
            Hair = hair;
            Eyes = eyes;
            Height = height;
            Build = build;
            Finger_Print = fingerPrint;
            Glasses = glasses;
        }


    }
}
