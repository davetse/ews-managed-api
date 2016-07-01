/*
 * Exchange Web Services Managed API
 *
 * Copyright (c) Microsoft Corporation
 * All rights reserved.
 *
 * MIT License
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this
 * software and associated documentation files (the "Software"), to deal in the Software
 * without restriction, including without limitation the rights to use, copy, modify, merge,
 * publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
 * to whom the Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all copies or
 * substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 * INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 * PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
 * FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 * OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
 * DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Exchange.WebServices.Data.Misc
{
    class AdjustmentRule
    {
        public DateTime DateEnd { get; private set; }
        public DateTime DateStart { get; private set; }
        public TimeSpan DaylightDelta { get; private set; }
        public TransitionTime DaylightTransitionEnd { get; private set; }
        public TransitionTime DaylightTransitionStart { get; private set; }

        public static AdjustmentRule CreateAdjustmentRule(
            DateTime dateStart,
            DateTime dateEnd,
            TimeSpan daylightDelta,
            TransitionTime daylightTransitionStart,
            TransitionTime daylightTransitionEnd)
        {
            AdjustmentRule adjustmentRule = new AdjustmentRule();
            adjustmentRule.DateStart = dateStart;
            adjustmentRule.DateEnd = dateEnd;
            adjustmentRule.DaylightDelta = daylightDelta;
            adjustmentRule.DaylightTransitionStart = daylightTransitionStart;
            adjustmentRule.DaylightTransitionEnd = daylightTransitionEnd;
            return adjustmentRule;
        }
    }
}
