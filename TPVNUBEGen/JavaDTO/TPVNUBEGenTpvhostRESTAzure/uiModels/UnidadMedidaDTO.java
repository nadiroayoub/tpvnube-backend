	
		package TPVNUBEGenTpvhostRESTAzure.uiModels.DTO;
		
		import java.util.ArrayList;
		
		import org.json.JSONArray;
		import org.json.JSONException;
		import org.json.JSONObject;
		import  TPVNUBEGenTpvhostRESTAzure.uiModels.DTO.utils.*;
		import  TPVNUBEGenTpvhostRESTAzure.uiModels.DTO.enumerations.*;
		
		
		/**
		 * Code autogenerated. Do not modify this file.
		 */
		
		
		public class UnidadMedidaDTO 	    implements IDTO
	    {
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
				private String descripcion;
				public String getDescripcion () { return descripcion; } 
				public void setDescripcion  (String value) { descripcion = value;  } 
				    	 
				private ArrayList<Integer> producto_oid;
				public ArrayList<Integer>  getProducto_oid () { return producto_oid; } 
				public void setProducto_oid (ArrayList<Integer> value) { producto_oid = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("Id", this.id.intValue());
				
				
						  json.put("Descripcion", this.descripcion);
				

						if (this.producto_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.producto_oid.size(); ++i)
							{
								jsonArray.put(this.producto_oid.get(i));
							}
							json.put("Producto_oid", jsonArray);
						}
		
						
					}
					catch (JSONException e)
					{
						e.printStackTrace();
					}
				
				return json;
			}
		
			// endregion
		}
	   
	   
	   
		
	