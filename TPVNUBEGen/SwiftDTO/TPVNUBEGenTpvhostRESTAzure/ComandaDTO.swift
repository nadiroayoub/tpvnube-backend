	
		//
		// ComandaDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class ComandaDTO 	    {
		 
				var id: Int?;
				    	 
		 
				var estadoComanda: EstadoComanda?;
				    	 
		 
				var lineaComanda: [LineaComandaDTO]?;
				    	 
		 
				var pago_oid: [Int]?;
				    	 
		 
				var mesa_oid: Int?;
				    	 
		 
				var factura_oid: Int?;
				    	 
		 
				var fecha: NSDate?;
				    	 
		 
				var empleado_oid: Int?;
				    	 
		 
				var total: Double?;
				    	 
	   	   
			// MARK: - Constructor
			
			
		
			init ()
			{
				// Empty constructor
			}
			 func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
			


				
					dictionary["id"] = self.id;
				

				
					dictionary["estadoComanda"] = self.estadoComanda?.rawValue;
				

					dictionary["lineaComanda"] = NSNull();
					if (self.lineaComanda != nil)
					{
						var arrayOfDictionary: [[String : AnyObject]] = [];
						for item in self.lineaComanda!
						{
							arrayOfDictionary.append(item.toDictionary());
						}
						
						dictionary["lineaComanda"] = arrayOfDictionary;
					}
			

					dictionary["pago_oid"] = self.pago_oid;
			

					dictionary["mesa_oid"] = self.mesa_oid;
			

					dictionary["factura_oid"] = self.factura_oid;
			

				
					dictionary["fecha"] = self.fecha?.toString();
				

					dictionary["empleado_oid"] = self.empleado_oid;
			

				
					dictionary["total"] = self.total;
				
						
				return dictionary;
			}
		}
		
	