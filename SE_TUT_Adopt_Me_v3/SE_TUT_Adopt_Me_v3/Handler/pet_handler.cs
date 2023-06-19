using SE_TUT_Adopt_Me_v3.Model;
using SE_TUT_Adopt_Me_v3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Handler
{
    public class pet_handler
    {
        public void AddPet(string shopId, string petName, int umur, int price, string gender, string species, string petImagePath)
        {
            // Check if the required fields are filled
            if (string.IsNullOrEmpty(shopId) || string.IsNullOrEmpty(petName) || umur <= 0 || price <= 0 || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(species) || string.IsNullOrEmpty(petImagePath))
            {
                throw new InvalidOperationException("Required fields must be filled.");
            }

            pet_repo.AddPet(shopId, petName, umur, price, gender, species, petImagePath);
        }

        public void UpdatePet(string petId, string shopId, string petName, int umur, int price, string gender, string species, string petImagePath)
        {
            // Check if the required fields are filled
            if (string.IsNullOrEmpty(shopId) || string.IsNullOrEmpty(petName) || umur <= 0 || price <= 0 || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(species) || string.IsNullOrEmpty(petImagePath))
            {
                throw new InvalidOperationException("Required fields must be filled.");
            }

            pet_repo.UpdatePet(petId, shopId, petName, umur, price, gender, species, petImagePath);
        }

        public void DeletePet(string petId)
        {
            pet_repo.DeletePet(petId);
        }

        public pet GetPetById(string petId)
        {
            return pet_repo.GetPetById(petId);
        }

        public List<pet> GetAllPets()
        {
            return pet_repo.GetAllPets();
        }
    }
}