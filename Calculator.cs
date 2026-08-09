using System;

namespace SafeUnsafeAdder
{
    /// <summary>
    /// Holds the two versions of the addition routine that this ICE task asks for:
    /// one written entirely in safe (managed, bounds-checked) code, and one written
    /// in an unsafe block that walks the array with a pointer.
    /// </summary>
    internal static class Calculator
    {
        /// <summary>
        /// SAFE CODE.
        /// The CLR manages the memory for us. Every array access is bounds-checked,
        /// so an out-of-range index throws an exception instead of corrupting memory.
        /// </summary>
        public static int AddSafe(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            int total = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                total += numbers[i];
            }

            return total;
        }

        /// <summary>
        /// UNSAFE CODE.
        /// The 'unsafe' keyword lets us declare and use pointers. 'fixed' pins the array
        /// in memory so the garbage collector cannot move it while the pointer is alive.
        /// We then add the values by dereferencing the pointer and stepping it forward,
        /// with no bounds checking done for us.
        /// Requires "Allow unsafe code" to be ticked in the project build properties.
        /// </summary>
        public static unsafe int AddUnsafe(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            // 'fixed' on an empty array yields a null pointer, so guard against it.
            if (numbers.Length == 0)
            {
                return 0;
            }

            int total = 0;

            fixed (int* firstElement = numbers)
            {
                int* current = firstElement;

                for (int i = 0; i < numbers.Length; i++)
                {
                    total += *current;  // read the value the pointer is aimed at
                    current++;          // move the pointer on to the next int
                }
            }

            return total;
        }
    }
}
