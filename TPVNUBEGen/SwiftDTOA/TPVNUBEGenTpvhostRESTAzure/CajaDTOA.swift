//
// CajaDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class CajaDTOA : DTOA
{
	// MARK: - Properties

	var id: Int?;
	
	var saldo: Double?;
	var descripcion: String?;
	var fondo: Double?;
	
	/* Rol: Caja o--> DuenyoRegistrado */
	var duenyo: DuenyoRegistradoDTOA?;

	/* Rol: Caja o--> Cobro */
	var cobros: [CobroDTOA]?;

	/* Rol: Caja o--> Negocio */
	var negocioCaja: NegocioDTOA?;

	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		self.id = json["Id"].object as? Int
		
	
		self.saldo = json["Saldo"].object as? Double;
		self.descripcion = json["Descripcion"].object as? String;
		self.fondo = json["Fondo"].object as? Double;
		
		if (json["Duenyo"] != JSON.null)
		{
			self.duenyo = DuenyoRegistradoDTOA(fromJSONObject: json["Duenyo"]);
		}

		if (json["Cobros"] != JSON.null)
		{
			self.cobros = CobroDTOA(fromJSONObject: json["Cobros"]);
		}

		if (json["NegocioCaja"] != JSON.null)
		{
			self.negocioCaja = NegocioDTOA(fromJSONObject: json["NegocioCaja"]);
		}

		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["Id"] = self.id;
		
	

	
		dictionary["Saldo"] = self.saldo;
	
	

	
		dictionary["Descripcion"] = self.descripcion;
	
	

	
		dictionary["Fondo"] = self.fondo;
	
	
		
		dictionary["Duenyo"] = self.duenyo?.toDictionary() ?? NSNull();

		dictionary["Cobros"] = self.cobros?.toDictionary() ?? NSNull();

		dictionary["NegocioCaja"] = self.negocioCaja?.toDictionary() ?? NSNull();

		
		
		return dictionary;
	}
}

	