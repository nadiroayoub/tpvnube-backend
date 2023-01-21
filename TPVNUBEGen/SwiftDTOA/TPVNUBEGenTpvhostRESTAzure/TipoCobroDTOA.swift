//
// TipoCobroDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class TipoCobroDTOA : DTOA
{
	// MARK: - Properties

	var id: Int?;
	
	var descripcion: String?;
	
	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		self.id = json["Id"].object as? Int
		
	
		self.descripcion = json["Descripcion"].object as? String;
		
		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["Id"] = self.id;
		
	

	
		dictionary["Descripcion"] = self.descripcion;
	
	
		
		
		
		return dictionary;
	}
}

	