﻿/*
 * The MIT License (MIT)
 *
 * Copyright (c) 2013-2020  Denis Kuzmin < x-3F@outlook.com > GitHub/3F
 * Copyright (c) MvsSln contributors: https://github.com/3F/MvsSln/graphs/contributors
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
*/

using System;
using System.Collections.Generic;

namespace net.r_eg.MvsSln.Core
{
    /// <summary>
    /// Isolated environment.
    /// </summary>
    public class IsolatedEnv: XProjectEnv, IXProjectEnv, IEnvironment, IDisposable
    {
        /// <param name="data">Prepared data from solution parser.</param>
        /// <param name="properties">Specified sln properties.</param>
        /// <param name="raw">Optional dictionary of raw xml projects by Guid.</param>
        public IsolatedEnv(ISlnResult data, IDictionary<string, string> properties, IDictionary<string, RawText> raw = null)
            : base(data, properties, raw)
        {

        }

        /// <param name="data">Prepared data from solution parser.</param>
        /// <param name="raw">Optional dictionary of raw xml projects by Guid.</param>
        public IsolatedEnv(ISlnResult data, IDictionary<string, RawText> raw = null)
            : base(data, raw)
        {

        }

        #region IDisposable

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposed) {
                return;
            }
            disposed = true;

            if(Projects != null) {
                UnloadAll(false);
            }
        }

        #endregion
    }
}