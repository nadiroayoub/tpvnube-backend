	
		//
		// MenuDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class MenuDTO 	    {
		 
				var id: Int?;
				    	 
		 
				var nombre: String?;
				    	 
		 
				var stock: Double?;
				    	 
		 
				var lineaComanda_oid: [Int]?;
				    	 
		 
				var lineaMenu: [LineaMenuDTO]?;
				    	 
		 
				var foto: String?;
				    	 
		 
				var precio: Double?;
				    	 
		 
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
				

					dictionary["lineaComanda_oid"] = self.lineaComanda_oid;
			

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
				

				
					dictionary["precio"] = self.precio;
				

					dictionary["negocio_oid"] = self.negocio_oid;
			
						
				return dictionary;
			}
		}
		
	