	
		//
		// PlatoDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class PlatoDTO 	    {
		 
				var id: Int?;
				    	 
		 
				var nombre: String?;
				    	 
		 
				var stock: Double?;
				    	 
		 
				var precio: Double?;
				    	 
		 
				var lineaPlato: [LineaPlatoDTO]?;
				    	 
		 
				var lineaMenu: [LineaMenuDTO]?;
				    	 
		 
				var foto: String?;
				    	 
		 
				var tipoPlato_oid: Int?;
				    	 
		 
				var lineaComanda_oid: [Int]?;
				    	 
		 
				var negocio_oid: Int?;
				    	 
	   	   
			// MARK: - Constructor
			
			
		
			init ()
			{
				// Empty constructor
			}
			 func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
			


				
					dictionary["id"] = self.id;
				

				
					dictionary["nombre"] = self.nombre;
				

				
					dictionary["stock"] = self.stock;
				

				
					dictionary["precio"] = self.precio;
				

					dictionary["lineaPlato"] = NSNull();
					if (self.lineaPlato != nil)
					{
						var arrayOfDictionary: [[String : AnyObject]] = [];
						for item in self.lineaPlato!
						{
							arrayOfDictionary.append(item.toDictionary());
						}
						
						dictionary["lineaPlato"] = arrayOfDictionary;
					}
			

					dictionary["lineaMenu"] = NSNull();
					if (self.lineaMenu != nil)
					{
						var arrayOfDictionary: [[String : AnyObject]] = [];
						for item in self.lineaMenu!
						{
							arrayOfDictionary.append(item.toDictionary());
						}
						
						dictionary["lineaMenu"] = arrayOfDictionary;
					}
			

				
					dictionary["foto"] = self.foto;
				

					dictionary["tipoPlato_oid"] = self.tipoPlato_oid;
			

					dictionary["lineaComanda_oid"] = self.lineaComanda_oid;
			

					dictionary["negocio_oid"] = self.negocio_oid;
			
						
				return dictionary;
			}
		}
		
	