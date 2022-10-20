using SpaceDebris.Web.Interfaces;
using SpaceDebris.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web;


namespace SpaceDebris.Web.Models.DTOs
{
    public class ImgTextBtnDTO : IBaseDtoModel
    {
        public List<ButtonCompositionDTO> Button { get; set; }
        public string ImageUrl { get; set; }
        public string Textbox { get; set; }
        public ImgTextBtnDTO()
        {
        }
        public ImgTextBtnDTO(ImgTextBtn imgTextBtn)
        {
            Button = new List<ButtonCompositionDTO>();
            foreach (var item in imgTextBtn.Button)
            {
                var validDto = new ButtonCompositionDTO(item);
                if(validDto.IsValid())
                    Button.Add(validDto);
            }
            ImageUrl = imgTextBtn.Image.Url().ToString();
            Textbox = imgTextBtn.Textbox;
        }
        public bool IsValid() 
        {
            return !string.IsNullOrEmpty(ImageUrl?.Trim()) && !string.IsNullOrEmpty(Textbox?.Trim());
        }
    }
}