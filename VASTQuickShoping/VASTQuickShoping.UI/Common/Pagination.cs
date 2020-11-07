using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace VASTQuickShoping.UI.Common
{
    public class Pagination
    {

        public int TotalItems { get; private set; }

        public int CurrentPage { get; private set; }

        public int PageSize { get; private set; }


        public int TotalPages { get; private set; }


        public int StartPage { get; private set; }

        public int EndPage { get; private set; }

        public int PreviousPage { get; private set; }

        public int NextPage { get; private set; }


        public Pagination(int pTotalItems, int? pCurrentPage, int pPageSize = 5)
        {
            int totalPages =(int)Math.Ceiling((decimal) pTotalItems / (decimal)pPageSize);

            int currentPage = pCurrentPage !=null ? (int)pCurrentPage :1;

            int startPage =(int) CurrentPage - 5;
            int EndPage = (int)CurrentPage + 4;

            if (StartPage <= 0){

                EndPage = EndPage - (startPage - 1);
                startPage = 1;
            }


            if (EndPage >totalPages)
            {

                EndPage = totalPages;
               if( EndPage > 10)
                {
                    startPage = EndPage - 9;
                }
            }

           

            this.TotalItems = TotalItems;
            this.CurrentPage = currentPage;
            this.PageSize = pPageSize;
            this.TotalItems = totalPages;
            this.StartPage = startPage;
            this.EndPage = EndPage;
            this.PreviousPage = currentPage == 1 ? 1: currentPage -1;
            this.NextPage = currentPage == TotalPages ? TotalPages : currentPage + 1; ;




        }
    }
}