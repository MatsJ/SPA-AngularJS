using System;
using System.Collections.Generic;
using oblig3_s198530.Models;
namespace oblig3_s198530
{
    interface IFAQDB
    {
        List<FAQ> getAllFAQ();
        FAQ getAFAQ(int id);
        bool addFAQ(question faq);
        List<FAQ> getFAQCategory(int id);
        List<question> listNewQuestions();
    }
}