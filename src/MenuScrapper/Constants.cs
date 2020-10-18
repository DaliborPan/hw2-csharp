using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuScrapper
{
    //Not necessary to edit this class. 
    public static class Constants
    {
        public static string bogotaURL = "https://www.fi.muni.cz/~xorsula1/resources/c%23_menicka/Restaurace%20Bogota.html";
        public static string udrevakaUrl = "https://www.udrevaka.cz/denni-menu/";
        public static string alCaponeUrl = "https://www.pizzaalcapone.cz/cz/poledni-menu";
        public static string testHtml = "<!DOCTYPE html>" +
                                        "<html>" +
                                            "<body>" +
                                                "<h1>My First Heading</h1>" +
                                                "<a href='https://www.w3schools.com'>This is a link 1</a>" +
                                                "<p>My first paragraph.</p>" +
                                                "<div class='c1 c'>" +
                                                    "<a href='https://www.w3schools.com'>This is a link 2.1</a>" +
                                                    "<br/>" +
                                                    "<a href='https://www.w3schools.com'>This is a link 2.2</a>" +
                                                    "<div class='c2'>" +
                                                        "<p>My second paragraph.</p>" +
                                                        "<div id='id1'>" +
                                                            "<a href='https://www.w3schools.com'>This is a link 3</a>" +
                                                        "</div>" +
                                                    "</div>" +
                                                "</div>" +
                                            "</body>" +
                                        "</html>";
    }
}
