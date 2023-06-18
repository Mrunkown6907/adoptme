using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Factory
{
    public class pet_factory
    {
        public static pet CreatePet(string petId, string shopId, string petName, int umur, int price, string gender, string species, string petImagePath)
        {
            return new pet
            {
                pet_id = petId,
                shop_id = shopId,
                pet_name = petName,
                umur = umur,
                price = price,
                gender = gender,
                species = species,
                pet_image_path = petImagePath
            };
        }
    }
}