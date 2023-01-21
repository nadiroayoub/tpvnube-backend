	
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
		
		
		public class CajaDTO 	    implements IDTO
	    {
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
				private Integer negocio_oid;
				public Integer  getNegocio_oid () { return negocio_oid; } 
				public void setNegocio_oid (Integer value) { negocio_oid = value;  } 
				    	 
				private ArrayList<Integer> pago_oid;
				public ArrayList<Integer>  getPago_oid () { return pago_oid; } 
				public void setPago_oid (ArrayList<Integer> value) { pago_oid = value;  } 
				    	 
				private Double saldo;
				public Double getSaldo () { return saldo; } 
				public void setSaldo  (Double value) { saldo = value;  } 
				    	 
				private ArrayList<Integer> cobro_oid;
				public ArrayList<Integer>  getCobro_oid () { return cobro_oid; } 
				public void setCobro_oid (ArrayList<Integer> value) { cobro_oid = value;  } 
				    	 
				private String descripcion;
				public String getDescripcion () { return descripcion; } 
				public void setDescripcion  (String value) { descripcion = value;  } 
				    	 
				private Integer duenyo_oid;
				public Integer  getDuenyo_oid () { return duenyo_oid; } 
				public void setDuenyo_oid (Integer value) { duenyo_oid = value;  } 
				    	 
				private Double fondo;
				public Double getFondo () { return fondo; } 
				public void setFondo  (Double value) { fondo = value;  } 
				    	 
				private java.util.Date fecha;
				public java.util.Date getFecha () { return fecha; } 
				public void setFecha  (java.util.Date value) { fecha = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("Id", this.id.intValue());
				

						if (this.negocio_oid != null)
						{
							json.put("Negocio_oid", this.negocio_oid.intValue());
						}

						if (this.pago_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.pago_oid.size(); ++i)
							{
								jsonArray.put(this.pago_oid.get(i));
							}
							json.put("Pago_oid", jsonArray);
						}
		
					    if (this.saldo != null){											
						  json.put("Saldo", this.saldo);
				
						}

						if (this.cobro_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.cobro_oid.size(); ++i)
							{
								jsonArray.put(this.cobro_oid.get(i));
							}
							json.put("Cobro_oid", jsonArray);
						}
		
				
						  json.put("Descripcion", this.descripcion);
				

						if (this.duenyo_oid != null)
						{
							json.put("Duenyo_oid", this.duenyo_oid.intValue());
						}
				
						  json.put("Fondo", this.fondo);
				
				
						  json.put("Fecha", DateUtils.dateToFormatString(this.fecha));
				
						
					}
					catch (JSONException e)
					{
						e.printStackTrace();
					}
				
				return json;
			}
		
			// endregion
		}
	   
	   
	   
		
	