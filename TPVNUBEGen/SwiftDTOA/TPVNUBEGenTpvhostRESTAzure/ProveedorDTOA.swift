//
// ProveedorDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class ProveedorDTOA : DTOA
{
	// MARK: - Properties

	var id: Int?;
	
	var nombre: String?;
	var email: String?;
	var telefono: String?;
	
	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		self.id = json["Id"].object as? Int
		
	
		self.nombre = json["Nombre"].object as? String;
		self.email = json["Email"].object as? String;
		self.telefono = json["Telefono"].object as? String;
		
		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["Id"] = self.id;
		
	

	
		dictionary["Nombre"] = self.nombre;
	
	

	
		dictionary["Email"] = self.email;
	
	

	
		dictionary["Telefono"] = self.telefono;
	
	
		
		
		
		return dictionary;
	}
}

	