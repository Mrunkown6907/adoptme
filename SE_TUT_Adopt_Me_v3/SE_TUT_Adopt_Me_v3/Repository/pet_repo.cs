using SE_TUT_Adopt_Me_v3.Factory;
using SE_TUT_Adopt_Me_v3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE_TUT_Adopt_Me_v3.Repository
{
    public class pet_repo
    {
        static DatabaseEntities1 db = new DatabaseEntities1();

        public void AddPet(string shopId, string petName, int umur, int price, string gender, string species, string petImagePath)
        {
            pet_factory.CreatePet( shopId, petName, umur, price, gender, species, petImagePath);
            db.SaveChanges();
        }

        public void UpdatePet(string petId, string shopId, string petName, int umur, int price, string gender, string species, string petImagePath)
        {
            var existingPet = db.pets.Find(petId);
            if (existingPet != null)
            {
                existingPet.shop_id = shopId;
                existingPet.pet_name = petName;
                existingPet.umur = umur;
                existingPet.price = price;
                existingPet.gender = gender;
                existingPet.species = species;
                existingPet.pet_image_path = petImagePath;

                db.SaveChanges();
            }
        }

        public void DeletePet(string petId)
        {
            var pet = db.pets.Find(petId);
            if (pet != null)
            {
                db.pets.Remove(pet);
                db.SaveChanges();
            }
        }

        public pet GetPetById(string petId)
        {
            return db.pets.Find(petId);
        }

        public List<pet> GetAllPets()
        {
            return db.pets.ToList();
        }
    }
}