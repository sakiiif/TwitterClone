using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Text;

namespace TwitterClone.Application.Dtos.Retweet
{
    internal class RetweetCommentValidator
    {
        public static IEnumerable<ValidationResult> Validate(string? comment, string memberName)
        {
            if (comment != null && comment.Length > Domain.Entities.Tweet.MaxContentLength)
            {
                yield return new ValidationResult(
                    $"Retweet comment cannot be longer than {Domain.Entities.Tweet.MaxContentLength} characters.",
                    new[] { memberName });
            }
        }
    }
}
