﻿using SimpleCRM.Entities.Models;

namespace SimpleCRM.Contracts
{
	/// <summary>
	/// Interface for customer repository, providing methods for CRUD operations on Customer entities.
	/// </summary>
	public interface ICustomerRepository : IRepositoryBase<Customer>
	{
		IEnumerable<Customer> GetAllCustomers();
		Customer? GetCustomerById(int id);
		void CreateCustomer(Customer customer);

		void DeleteCustomer(Customer customer);

		void UpdateCustomer(Customer customer);
	}
}
