﻿using System;
using System.Runtime.InteropServices;

namespace LibDeflate.Imports
{
    using size_t = System.UIntPtr;

    public static class CustomMemoryAllocator
    {
        public delegate IntPtr malloc_func(size_t size);
        public delegate void free_func(IntPtr alloc);

        ///<summary>
        /// Install a custom memory allocator which libdeflate will use for all memory
        /// allocations.  'malloc_func' is a function that must behave like malloc(), and
        /// 'free_func' is a function that must behave like free().
        ///
        /// There must not be any libdeflate_compressor or libdeflate_decompressor
        /// structures in existence when calling this function.
        ///</summary>
        [DllImport(Constants.DllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void libdeflate_set_memory_allocator(malloc_func malloc, free_func free);
    }
}
