// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="ResourceNotFoundResult.cs" company="Andrew Nurse">
//   Copyright (c) 2009 Andrew Nurse.  Licensed under the Ms-PL license: http://opensource.org/licenses/ms-pl.html
// </copyright>
// <summary>
//   Defines the ResourceNotFoundResult type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------

using System;
using System.Web.Mvc;

namespace Maverick.Web.Helpers {
    public class ResourceNotFoundResult : ActionResult {
        private static readonly Func<ActionResult> FallbackInnerResultFactory = () => new EmptyResult();
        
        private static Func<ActionResult> _defaultInnerResultFactory;
        
        public static Func<ActionResult> DefaultInnerResultFactory {
            get {
                if(_defaultInnerResultFactory == null) {
                    return FallbackInnerResultFactory;
                }
                return _defaultInnerResultFactory;
            }
            set { _defaultInnerResultFactory = value; }
        }

        public ActionResult InnerResult { get; set; }

        public override void ExecuteResult(ControllerContext context) {
            context.HttpContext.Response.StatusCode = 404;
            ActionResult result = InnerResult;
            if(result == null) {
                result = DefaultInnerResultFactory();
            }
            result.ExecuteResult(context);
        }
    }
}
