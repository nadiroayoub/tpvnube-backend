	
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
		
		
		public class LineaCompraProveedorDTO 	    implements IDTO
	    {
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
				private Integer cantidad;
				public Integer getCantidad () { return cantidad; } 
				public void setCantidad  (Integer value) { cantidad = value;  } 
				    	 
				private Integer servicio_oid;
				public Integer  getServicio_oid () { return servicio_oid; } 
				public void setServicio_oid (Integer value) { servicio_oid = value;  } 
				    	 
				private Integer compraProveedor_oid;
				public Integer  getCompraProveedor_oid () { return compraProveedor_oid; } 
				public void setCompraProveedor_oid (Integer value) { compraProveedor_oid = value;  } 
				    	 
				private Integer producto_oid;
				public Integer  getProducto_oid () { return producto_oid; } 
				public void setProducto_oid (Integer value) { producto_oid = value;  } 
				    	 
				private Double costo;
				public Double getCosto () { return costo; } 
				public void setCosto  (Double value) { costo = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("Id", this.id.intValue());
				
				
						  json.put("Cantidad", this.cantidad.intValue());
				

						if (this.servicio_oid != null)
						{
							json.put("Servicio_oid", this.servicio_oid.intValue());
						}

						if (this.compraProveedor_oid != null)
						{
							json.put("CompraProveedor_oid", this.compraProveedor_oid.intValue());
						}

						if (this.producto_oid != null)
						{
							json.put("Producto_oid", this.producto_oid.intValue());
						}
				
						  json.put("Costo", this.costo);
				
						
					}
					catch (JSONException e)
					{
						e.printStackTrace();
					}
				
				return json;
			}
		
			// endregion
		}
	   
	   
	   
		
	