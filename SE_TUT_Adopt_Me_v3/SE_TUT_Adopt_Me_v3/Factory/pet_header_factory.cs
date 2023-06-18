using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Factory
{
    public class pet_header_factory
    {
        public static pet_header CreatePetHeader(int petHeaderId, string cartId, string petId)
        {
            return new pet_header
            {
                pet_header_id = petHeaderId,
                cart_id = cartId,
                pet_id = petId,
                quantity = 1
            };
        }
    }
}