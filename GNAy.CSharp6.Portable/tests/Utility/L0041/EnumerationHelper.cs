using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region .NET Framework namespace.
using System.Diagnostics;
using System.Diagnostics.Contracts;
#endregion

#region Third party library.
#endregion

#region GNAy namespace.
#if Development
using GNAy.CSharp6.Portable.Const.L0000_ConstNumberValue;
using GNAy.CSharp6.Portable.Const.L0010_ConstString;
using GNAy.CSharp6.Portable.Const.L0010_ConstValue;
using GNAy.CSharp6.Portable.Utility.L0020_StringHelper;
using GNAy.CSharp6.Portable.Utility.L0030_EnumerationInformation;
using GNAy.CSharp6.Portable.Utility.L0040_EnumerationHelper;
#else
using GNAy.CSharp6.Portable.Const;
using GNAy.CSharp6.Portable.Utility;
#endif
#endregion

#region Alias.
#if Development
using PortableEnumerationHelper = GNAy.CSharp6.Portable.Utility.L0040_EnumerationHelper.EnumerationHelper;
#else
using PortableEnumerationHelper = GNAy.CSharp6.Portable.Utility.EnumerationHelper;
#endif
#endregion

#if Development
namespace GNAy.CSharp6.Portable.Tests.Utility.L0041_EnumerationHelper
#else
namespace GNAy.CSharp6.Portable.Tests.Utility
#endif
{
    /// <summary>
    /// <para>Don't use GNAy.CSharp6.Portable.Tests.Utility.</para>
    /// </summary>
    public class EnumerationHelper
    {
        static EnumerationHelper()
        {
#if Development
            CSharp6.Portable.Tests.Sample.L0000_UnitTest.UnitTest.Initialize();
#else
            CSharp6.Portable.Tests.Sample.UnitTest.Initialize();
#endif
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetEnumInfo()
        {
            //arrange
            const int mArgument1 = (10 * 10000);
            Stopwatch mArgument2 = new Stopwatch();
            const AttributeTargets mArgument3 = (AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Delegate);
            EnumerationInformation mArgument4 = mArgument3.zzGetInfo();
            EnumerationInformation[] mArgument5 = mArgument3.zzForeachFlagInfo().ToArray();
            bool mActualA1 = false;
            bool mActualA2 = false;
            bool mActualA3 = false;
            bool mActualA4 = false;
            int mActualB1 = ConstNumberValue.Zero;
            long mActualB2 = ConstNumberValue.Zero;
            int mActualB3 = ConstNumberValue.Zero;
            long mActualB4 = ConstNumberValue.Zero;
            bool mActualB5 = false;
            bool mActualB6 = false;
            string mActualC1 = ConstString.Empty;
            long mActualC2 = ConstNumberValue.Zero;
            string mActualC3 = ConstString.Empty;
            long mActualC4 = ConstNumberValue.Zero;
            bool mActualC5 = false;
            bool mActualC6 = false;
            bool mActualD1 = true;
            long mActualD2 = ConstNumberValue.Zero;
            bool mActualD3 = true;
            long mActualD4 = ConstNumberValue.Zero;
            bool mActualD5 = false;
            bool mActualD6 = false;
            Enum[] mActualE1 = null;
            long mActualE2 = ConstNumberValue.Zero;
            Array mActualE3 = null;
            long mActualE4 = ConstNumberValue.Zero;
            bool mActualE5 = false;
            bool mActualE6 = false;
            string[] mActualF1 = null;
            long mActualF2 = ConstNumberValue.Zero;
            string[] mActualF3 = null;
            long mActualF4 = ConstNumberValue.Zero;
            bool mActualF5 = false;
            bool mActualF6 = false;

            //act
            //Foreach flag info.
            mActualA1 = ((AttributeTargets)mArgument5[ConstValue.StartIndex].Source == AttributeTargets.Constructor);
            mActualA2 = ((AttributeTargets)mArgument5[ConstValue.StartIndex + ConstNumberValue.One].Source == AttributeTargets.Method);
            mActualA3 = ((AttributeTargets)mArgument5[ConstValue.StartIndex + ConstNumberValue.Two].Source == AttributeTargets.Field);
            mActualA4 = ((AttributeTargets)mArgument5[ConstValue.StartIndex + ConstNumberValue.Three].Source == AttributeTargets.Delegate);

            Debug.WriteLine(StringHelper.DefaultJoin(mArgument3, mActualA1, mActualA2, mActualA3, mActualA4, mArgument5[ConstValue.StartIndex].Source, mArgument5[ConstValue.StartIndex + ConstNumberValue.One].Source, mArgument5[ConstValue.StartIndex + ConstNumberValue.Two].Source, mArgument5[ConstValue.StartIndex + ConstNumberValue.Three].Source));

            //Get value.
            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = ConstValue.StartIndex; i < mArgument1; ++i)
            {
                mActualB1 = mArgument4.Value;
            }
            mArgument2.Stop();
            mActualB2 = mArgument2.ElapsedTicks;

            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = ConstValue.StartIndex; i < mArgument1; ++i)
            {
                mActualB3 = (int)mArgument3;
            }
            mArgument2.Stop();
            mActualB4 = mArgument2.ElapsedTicks;

            mActualB5 = (mActualB1 == mActualB3);
            mActualB6 = (mActualB2 > mActualB4);
            Debug.WriteLine(StringHelper.DefaultJoin(mActualB1, mActualB3, mActualB5, mActualB2, mActualB4, ((double)mActualB2 / mActualB4)));

            //Get name.
            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = ConstValue.StartIndex; i < mArgument1; ++i)
            {
                mActualC1 = mArgument4.Name;
            }
            mArgument2.Stop();
            mActualC2 = mArgument2.ElapsedTicks;

            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = ConstValue.StartIndex; i < mArgument1; ++i)
            {
                mActualC3 = mArgument3.ToString();
            }
            mArgument2.Stop();
            mActualC4 = mArgument2.ElapsedTicks;

            mActualC5 = (mActualC1 == mActualC3);
            mActualC6 = (mActualC2 < mActualC4);
            Debug.WriteLine(StringHelper.DefaultJoin(mActualC1, mActualC3, mActualC5, mActualC2, mActualC4, ((double)mActualC4 / mActualC2)));

            //Get IsDefined.
            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = ConstValue.StartIndex; i < mArgument1; ++i)
            {
                mActualD1 = mArgument4.IsDefined;
            }
            mArgument2.Stop();
            mActualD2 = mArgument2.ElapsedTicks;

            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = ConstValue.StartIndex; i < mArgument1; ++i)
            {
                mActualD3 = Enum.IsDefined(mArgument3.GetType(), mArgument3);
            }
            mArgument2.Stop();
            mActualD4 = mArgument2.ElapsedTicks;

            mActualD5 = (mActualD1 == mActualD3);
            mActualD6 = (mActualD2 < mActualD4);
            Debug.WriteLine(StringHelper.DefaultJoin(mActualD1, mActualD3, mActualD5, mActualD2, mActualD4, ((double)mActualD4 / mActualD2)));

            //Get RawCollection.
            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = ConstValue.StartIndex; i < mArgument1; ++i)
            {
                mActualE1 = mArgument4.RawCollection;
            }
            mArgument2.Stop();
            mActualE2 = mArgument2.ElapsedTicks;

            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = ConstValue.StartIndex; i < mArgument1; ++i)
            {
                mActualE3 = Enum.GetValues(mArgument3.GetType());
            }
            mArgument2.Stop();
            mActualE4 = mArgument2.ElapsedTicks;

            mActualE5 = (string.Join(",", (IEnumerable<Enum>)mActualE1) == string.Join(",", mActualE3.Cast<Enum>()));
            mActualE6 = (mActualE2 < mActualE4);
            Debug.WriteLine(StringHelper.DefaultJoin(string.Join(",", mActualE3.Cast<Enum>()), mActualE5, mActualE2, mActualE4, ((double)mActualE4 / mActualE2)));

            //Get NameCollection.
            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = ConstValue.StartIndex; i < mArgument1; ++i)
            {
                mActualF1 = mArgument4.NameCollection;
            }
            mArgument2.Stop();
            mActualF2 = mArgument2.ElapsedTicks;

            mArgument2.Reset();
            Debug.WriteLine(mArgument2.ElapsedTicks);
            mArgument2.Start();
            for (int i = ConstValue.StartIndex; i < mArgument1; ++i)
            {
                mActualF3 = Enum.GetNames(mArgument3.GetType());
            }
            mArgument2.Stop();
            mActualF4 = mArgument2.ElapsedTicks;

            mActualF5 = (string.Join(",", mActualF1) == string.Join(",", mActualF3));
            mActualF6 = (mActualF2 < mActualF4);
            Debug.WriteLine(StringHelper.DefaultJoin(string.Join(",", mActualF3), mActualF5, mActualF2, mActualF4, ((double)mActualF4 / mActualF2)));

            //assert
            Contract.Assert(mActualA1);
            Contract.Assert(mActualA2);
            Contract.Assert(mActualA3);
            Contract.Assert(mActualA4);
            Contract.Assert(mActualB5);
            Contract.Assert(mActualB6);
            Contract.Assert(mActualC5);
            Contract.Assert(mActualC6);
            Contract.Assert(!mActualD1);
            Contract.Assert(!mActualD3);
            Contract.Assert(mActualD5);
            Contract.Assert(mActualD6);
            Contract.Assert(mActualE5);
            Contract.Assert(mActualE6);
            Contract.Assert(mActualF5);
            Contract.Assert(mActualF6);
        }
    }
}
