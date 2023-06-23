using Microsoft.AspNetCore.Mvc;

namespace XTLAB
{
    //[ViewComponent]
    public class ProductBox : ViewComponent
    {
        //Invoke(objecct)

        /*
            - [ViewConponent]
            - Ten lop co hau to ViewComponent
            - Ke thua ViewComponent

        */
        public string Invoke()
        {
            return "Noi dung cua ProductBox";
        }
    }
}