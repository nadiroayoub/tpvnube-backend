	
		//
		// TipoPlatoDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class TipoPlatoDTO 	    {
		 
				var id: Int?;
				    	 
		 
				var nombre: String?;
				    	 
		 
				var plato_oid: [Int]?;
				    	 
	   	   
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
				

					dictionary["plato_oid"] = self.plato_oid;
			
						
				return dictionary;
			}
		}
		
	