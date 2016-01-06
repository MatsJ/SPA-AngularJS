using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using oblig3_s198530.Models;

namespace oblig3_s198530
{
    public class FAQDB : IFAQDB
    {
        FAQContext db = new FAQContext();

        //henter alle spørsmål
        public List<FAQ> getAllFAQ()
        {
            List<FAQ> allFAQ = db.Faq.Select(f => new FAQ()
            {
                id = f.Id,
                name = f.Name,
                email = f.Email,
                category = f.Category.Name,
                categoryID = f.Category.Id,
                title = f.Title,
                question = f.Question,
                answer = f.Answer,
                clicks = f.Clicks
            }).ToList();
            return allFAQ;

        }


        //henter et spørsmål
        public FAQ getAFAQ(int id)
        {
            Faq aFAQ = db.Faq.Find(id);

            var FAQS = new FAQ()
            {
                id = aFAQ.Id,
                name = aFAQ.Name,
                email = aFAQ.Email,
                category = aFAQ.Category.Name,
                categoryID = aFAQ.Category.Id,
                title = aFAQ.Title,
                question = aFAQ.Question,
                answer = aFAQ.Answer,
                clicks = aFAQ.Clicks
            };
            return FAQS;
        }

        //legger til et spørsmål
        public bool addFAQ(question faq)
        {
            var newFaq = new Question()
            {
                category = faq.Category,
                question = faq.Question  
            };

            try
            {
                db.Question.Add(newFaq);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }

        public List<category> getCategories()
        {
            List<category> categories = db.Categories.Select(c => new category()
            {
                id = c.Id,
                name = c.Name
            }).ToList();

            return categories;
        }

        //henter 1 kategori
        public List<FAQ> getFAQCategory(int categoryid)
        {
            List<FAQ> catfaq = new List<FAQ>();
            var faq = db.Faq.Where(p => p.Category.Id == categoryid).ToList();
            foreach(var x in faq)
            {
                var f = new FAQ()
                {
                    id = x.Id,
                    name = x.Name,
                    answer = x.Answer,
                    question = x.Question,
                    category = x.Category.Name,
                    categoryID = x.Category.Id
                };
                catfaq.Add(f);
            }
            return catfaq;
            /*
            List<FAQ> list = new List<FAQ>();
            foreach (FAQ item in faq)
            {
                if (item.categoryID == categoryid)
                {
                    list.Add(item);
                }
            }
            return list;
            */
        }

        //ubesvarte spørsmål
        public List<question> listNewQuestions()
        {
            List<question> newQuestion = db.Question.Select(f => new question() {
                Id = f.id,
                Category = f.category,
                Question = f.question
            }).ToList();

            return newQuestion;

        }
            

    }
}