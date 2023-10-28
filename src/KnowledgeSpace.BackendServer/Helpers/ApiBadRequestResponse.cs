using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeSpace.BackendServer.Helpers
{
    public class ApiBadRequestResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; }
        public ApiBadRequestResponse(ModelStateDictionary modelState) : base(400)
        {
            if (modelState == null)
            {
                throw new ArgumentException("ModelState must be invalid", nameof(modelState));
            }

            Errors = modelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage).ToList();
        }

        public ApiBadRequestResponse (IdentityResult identityResult) : base(400)
        {
            Errors = identityResult.Errors
                .Select(x => x.Code + " - " + x.Description).ToArray();  
        }

        public ApiBadRequestResponse(string message)
           : base(400, message)
        {
        }
    }
}
