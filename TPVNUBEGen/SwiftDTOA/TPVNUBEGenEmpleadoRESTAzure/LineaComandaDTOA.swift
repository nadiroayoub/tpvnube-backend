//
// LineaComandaDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class LineaComandaDTOA : DTOA
{
	// MARK: - Properties

	var id: Int?;
	
	var cantidad: Int?;
	
	/* Rol: LineaComanda o--> Plato */
	var platoOfLineaComanda: PlatoDTOA?;

	/* Rol: LineaComanda o--> Menu */
	var menuOfLineaComanda: MenuDTOA?;

	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		self.id = json["Id"].object as? Int
		
	
		self.cantidad = json["Cantidad"].object as? Int;
		
		if (json["PlatoOfLineaComanda"] != JSON.null)
		{
			self.platoOfLineaComanda = PlatoDTOA(fromJSONObject: json["PlatoOfLineaComanda"]);
		}

		if (json["MenuOfLineaComanda"] != JSON.null)
		{
			self.menuOfLineaComanda = MenuDTOA(fromJSONObject: json["MenuOfLineaComanda"]);
		}

		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["Id"] = self.id;
		
	

	
		dictionary["Cantidad"] = self.cantidad;
	
	
		
		dictionary["PlatoOfLineaComanda"] = self.platoOfLineaComanda?.toDictionary() ?? NSNull();

		dictionary["MenuOfLineaComanda"] = self.menuOfLineaComanda?.toDictionary() ?? NSNull();

		
		
		return dictionary;
	}
}

	