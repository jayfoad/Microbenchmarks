﻿using System.Text;

namespace AsmGen
{
    public class MixStoreSchedTest : UarchTest
    {
        public MixStoreSchedTest(int low, int high, int step)
        {
            this.Counts = UarchTestHelpers.GenerateCountArray(low, high, step);
            this.Prefix = "mixstoresched";
            this.Description = "Store (Mixed Data/Address) Scheduler Capacity Test";
            this.FunctionDefinitionParameters = "uint64_t iterations, int count, int *arr2";
            this.GetFunctionCallParameters = "structIterations, list_size, B";
            this.DivideTimeByCount = false;
        }

        public override void GenerateX86GccAsm(StringBuilder sb)
        {
            string[] dependentStores = new string[4];
            dependentStores[0] = "  mov %rdx, (%r8, %r15, 4)";
            dependentStores[1] = "  mov %r15, (%r8, %rdx, 4)";
            dependentStores[2] = "  mov %rdx, (%r8, %r15, 4)";
            dependentStores[3] = "  mov %r15, (%r8, %rdx, 4)";

            string[] dependentStores1 = new string[4];
            dependentStores1[0] = "  mov %rdx, (%r8, %r11, 4)";
            dependentStores1[1] = "  mov %r11, (%r8, %rdx, 4)";
            dependentStores1[2] = "  mov %rdx, (%r8, %r11, 4)";
            dependentStores1[3] = "  mov %r11, (%r8, %rdx, 4)";
            UarchTestHelpers.GenerateX86AsmDivStructureTestFuncs(sb, this.Counts, this.Prefix, dependentStores, dependentStores1, false);
        }

        public override void GenerateX86NasmAsm(StringBuilder sb)
        {
            string[] dependentStores = new string[4];
            dependentStores[0] = "  mov [r8 + r15 * 4], rdx";
            dependentStores[1] = "  mov [r8 + rdx * 4], r15";
            dependentStores[2] = "  mov [r8 + r15 * 4], rdx";
            dependentStores[3] = "  mov [r8 + rdx * 4], r15";

            string[] dependentStores1 = new string[4];
            dependentStores1[0] = "  mov [r8 + r11 * 4], rdx";
            dependentStores1[1] = "  mov [r8 + rdx * 4], r11";
            dependentStores1[2] = "  mov [r8 + r11 * 4], rdx";
            dependentStores1[3] = "  mov [r8 + rdx * 4], r11";
            UarchTestHelpers.GenerateX86NasmDivStructureTestFuncs(sb, this.Counts, this.Prefix, dependentStores, dependentStores1, false);
        }

        public override void GenerateArmAsm(StringBuilder sb)
        {
            string[] dependentStores = new string[4];
            dependentStores[0] = "  str w25, [x2, w15, uxtw #2]";
            dependentStores[1] = "  str w15, [x2, w25, uxtw #2]";
            dependentStores[2] = "  str w25, [x2, w15, uxtw #2]";
            dependentStores[3] = "  str w15, [x2, w25, uxtw #2]";

            string[] dependentStores1 = new string[4];
            dependentStores1[0] = "  str w26, [x2, w15, uxtw #2]";
            dependentStores1[1] = "  str w15, [x2, w26, uxtw #2]";
            dependentStores1[2] = "  str w26, [x2, w15, uxtw #2]";
            dependentStores1[3] = "  str w15, [x2, w26, uxtw #2]";
            UarchTestHelpers.GenerateArmAsmDivStructureTestFuncs(sb, this.Counts, this.Prefix, dependentStores, dependentStores1, false);
        }
    }
}
