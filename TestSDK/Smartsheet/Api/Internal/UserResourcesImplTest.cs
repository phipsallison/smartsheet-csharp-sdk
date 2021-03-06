﻿using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Smartsheet.Api.Models;

	public class UserResourcesImplTest : ResourcesImplBase
	{

		private UserResourcesImpl userResources;

		[SetUp]
		public virtual void SetUp()
		{
			userResources = new UserResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestUserResourcesImpl()
		{
		}
		[Test]
		public virtual void TestListUsers()
		{
			server.setResponseBody("../../../TestSDK/resources/listUsers.json");

			// Test that only one result is returned
			PaginatedResult<User> result = userResources.ListUsers(new string[] { "john.doe@smartsheet.com" }, new PaginationParameters(true, null, null));
			Assert.NotNull(result);
			IList<User> users = result.Data;
			Assert.AreEqual(2, users.Count);
			Assert.AreEqual(2421657013905284L, (long)users[0].Id);
			Assert.AreEqual("john.doe@smartsheet.com", users[0].Email);
			Assert.AreEqual("John Doe", users[0].Name);

			// Test that all are returned

			// Test that two are returned

			// Test tha none are returned


		}

		[Test]
		public virtual void TestAddUser()
		{
			server.setResponseBody("../../../TestSDK/resources/addUser.json");

			User user = new User.AddUserBuilder("NEW_USER_EMAIL", false, true).SetFirstName("John").SetLastName("Doe").Build();
			User newUser = userResources.AddUser(user, false, true);

			Assert.AreEqual("NEW_USER_EMAIL", newUser.Email);
			Assert.AreEqual("John Doe", newUser.Name);
			Assert.AreEqual(false, newUser.Admin);
			Assert.AreEqual(true, newUser.LicensedSheetCreator);
			Assert.AreEqual(1768423626696580L, (long)newUser.Id);
		}

		//[Test]
		//public virtual void TestAddUserUserBoolean()
		//{
		//	server.setResponseBody("../../../TestSDK/resources/addUser.json");

		//	User user = new User();
		//	user.Admin = true;
		//	user.Email = "test@test.com";
		//	user.FirstName = "test425";
		//	user.LastName = "test425";
		//	user.LicensedSheetCreator = true;
		//	User newUser = userResources.AddUser(user, false);

		//	Assert.AreEqual("test@test.com", newUser.Email);
		//	Assert.AreEqual("test425 test425", newUser.Name);
		//	Assert.AreEqual(false, newUser.Admin);
		//	Assert.AreEqual(true, newUser.LicensedSheetCreator);
		//	Assert.AreEqual(3210982882338692L, (long)newUser.ID);
		//}

		[Test]
		public virtual void TestGetCurrentUser()
		{
			server.setResponseBody("../../../TestSDK/resources/getCurrentUser.json");

			UserProfile user = userResources.GetCurrentUser();
			Assert.AreEqual("john.doe@smartsheet.com", user.Email);
			Assert.AreEqual(48569348493401200L, (long)user.Id);
			Assert.AreEqual("John", user.FirstName);
			Assert.AreEqual("Doe", user.LastName);
		}

		[Test]
		public virtual void TestUpdateUser()
		{
			server.setResponseBody("../../../TestSDK/resources/updateUser.json");

			User user = new User.UpdateUserBuilder(123L, true, true).Build();
			User updatedUser = userResources.UpdateUser(user);
			Assert.AreEqual(true, updatedUser.Admin);
			Assert.AreEqual(true, updatedUser.LicensedSheetCreator);
		}

		[Test]
		public virtual void TestDeleteUser()
		{
			server.setResponseBody("../../../TestSDK/resources/deleteUser.json");

			userResources.RemoveUser(123L, 456L, false, null);
		}
	}
}