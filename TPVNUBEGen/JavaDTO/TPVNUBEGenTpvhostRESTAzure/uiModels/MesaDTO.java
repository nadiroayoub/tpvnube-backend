	
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
		
		
		public class MesaDTO 	    implements IDTO
	    {
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
				private ArrayList<Integer> comanda_oid;
				public ArrayList<Integer>  getComanda_oid () { return comanda_oid; } 
				public void setComanda_oid (ArrayList<Integer> value) { comanda_oid = value;  } 
				    	 
				private EstadoMesa estado;
				public EstadoMesa getEstado () { return estado; } 
				public void setEstado  (EstadoMesa value) { estado = value;  } 
				    	 
				private Integer numero;
				public Integer getNumero () { return numero; } 
				public void setNumero  (Integer value) { numero = value;  } 
				    	 
				private Integer negocio_oid;
				public Integer  getNegocio_oid () { return negocio_oid; } 
				public void setNegocio_oid (Integer value) { negocio_oid = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("Id", this.id.intValue());
				

						if (this.comanda_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.comanda_oid.size(); ++i)
							{
								jsonArray.put(this.comanda_oid.get(i));
							}
							json.put("Comanda_oid", jsonArray);
						}
		
				
						  json.put("Estado", this.estado.getRawValue());
				
				
						  json.put("Numero", this.numero.intValue());
				

						if (this.negocio_oid != null)
						{
							json.put("Negocio_oid", this.negocio_oid.intValue());
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
	   
	   
	   
		
	