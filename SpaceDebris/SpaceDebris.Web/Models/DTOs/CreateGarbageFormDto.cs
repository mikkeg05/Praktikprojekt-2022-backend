using SpaceDebris.Web.Business.HelperMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceDebris.Web.Models.DTOs
{
    public class CreateGarbageFormDto
    {
        FormInput formInput = new FormInput();
        public CreateGarbageFormDto()
        {
            Inputs = new List<FormInput> {
                new FormInput("Weight", "weight", "Weight in kg", "number"),
                new FormInput("Length", "length", "Length in cm", "number"),
                new FormInput("Width", "width", "Width in cm", "number"),
                new FormInput("Depth/Height", "depth", "Depth in cm", "number"),
                new FormInput(string.Empty, "parentid", string.Empty, "hidden", Value)
            };
            
        }
        private string Value => formInput.GetId().ToString();
        public List<FormInput> Inputs { get; set; }
    }

    public class FormInput
    {
        public FormInput(string label, string name, string placeholder, string type)
        {
            Label = label;
            Name = name;
            Placeholder = placeholder;
            Type = type;
        }
        public FormInput(string label, string name, string placeholder, string type, string value)
        {
            Label = label;
            Name = name;
            Placeholder = placeholder;
            Type = type;
            Value = value;
        }


        public FormInput()
        {

        }
        public string Label { get; set; }
        public string Name { get; set; }
        public string Placeholder { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public int GetId() 
        {
            var garbageMain = PageHelper.GetPage("listOfItems").Children.FirstOrDefault(x => x.ContentType.Alias.Equals("garbageMain", StringComparison.OrdinalIgnoreCase));
            return garbageMain.Id;
        }
        

    }


}