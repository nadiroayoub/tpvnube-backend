	
		//
		// CajeroDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class CajeroDTO 	    {
		 
				var id: Int?;
				    	 
		 
				var rol_oid: [Int]?;
				    	 
		 
				var caja_oid: [Int]?;
				    	 
	   	   
			// MARK: - Constructor
			
			
		
			init ()
			{
				// Empty constructor
			}
			 func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
			


				
					dictionary["id"] = self.id;
				

					dictionary["rol_oid"] = self.rol_oid;
			

					dictionary["caja_oid"] = self.caja_oid;
			
						
				return dictionary;
			}
		}
		
	