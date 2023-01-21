//
// PedidoDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class PedidoDTOA : DTOA
{
	// MARK: - Properties

	var id: Int?;
	
	var estadoPedido: EstadoComanda?;
	var fecha: NSDate?;
	
	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		self.id = json["Id"].object as? Int
		
	
		if let enumValue = json["EstadoPedido"].object as? Int
		{
			self.estadoPedido = EstadoComanda(rawValue: enumValue);
		}
	
		self.fecha = NSDate.initFromString(json["Fecha"].object as? String);
		
		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["Id"] = self.id;
		
	

	
		dictionary["EstadoPedido"] = self.estadoPedido?.rawValue;
	
	

	
		dictionary["Fecha"] = self.fecha?.toString();
	
	
		
		
		
		return dictionary;
	}
}

	