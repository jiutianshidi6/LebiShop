using System;
using System.Collections.Generic;
using System.Web;

using Shop.Model;
using Shop.Bussiness;
using Shop.Tools;

namespace weixinpayh5
{
    public class WxPayException : Exception 
    {
        public WxPayException(string msg) : base(msg) 
        {

        }
     }
}