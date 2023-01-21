//
// CamareroDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class CamareroDTOA : DTOA
{
	// MARK: - Properties

	var id: Int?;
	
	
	/* Rol: Camarero o--> Pedido */
	var pedidos: [PedidoDTOA]?;

	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		self.id = json["Id"].object as? Int
		
	
		
		if (json["Pedidos"] != JSON.null)
		{
			self.pedidos = [];
			for subJson in json["Pedidos"].arrayValue
			{
				self.pedidos!.append(PedidoDTOA(fromJSONObject: subJson));
			}
		}

		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["Id"] = self.id;
		
	
		
		dictionary["Pedidos"] = NSNull();
		if (self.pedidos != nil)
		{
			var arrayOfDictionary: [[String : AnyObject]] = [];
			for item in self.pedidos!
			{
				arrayOfDictionary.append(item.toDictionary());
			}
			
			dictionary["Pedidos"] = arrayOfDictionary;
		}

		
		
		return dictionary;
	}
}

	