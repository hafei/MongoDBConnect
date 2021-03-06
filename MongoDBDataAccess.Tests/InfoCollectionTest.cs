// <copyright file="InfoCollectionTest.cs">Copyright ©  2017</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using RepositoryTests;

namespace Repository.Tests
{
    /// <summary>此类包含 InfoCollection 的参数化单元测试</summary>
    [PexClass(typeof(InfoCollection))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class InfoCollectionTest
    {
    }
}
